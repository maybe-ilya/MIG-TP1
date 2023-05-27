using MIG.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace MIG.Logging
{
    public sealed class LogService : ILogService
    {
        private readonly LogServiceSettings _settings;
        private readonly IReadOnlyList<ILogTarget> _targets;

        public LogService(LogServiceSettings settings, IReadOnlyList<ILogTarget> targets)
        {
            _settings = settings;
            _targets = targets;
        }

        public void Info(string message) =>
            SendMessage(LogChannel.None, LogLevel.INFO, message);

        public void Info(LogChannel channel, string message) =>
            SendMessage(channel, LogLevel.INFO, message);

        public void Warning(string message) =>
            SendMessage(LogChannel.None, LogLevel.WARNING, message);

        public void Warning(LogChannel channel, string message) =>
            SendMessage(channel, LogLevel.WARNING, message);

        public void Error(string message) =>
            SendMessage(LogChannel.None, LogLevel.ERROR, message);

        public void Error(LogChannel channel, string message) =>
            SendMessage(channel, LogLevel.ERROR, message);

        private void SendMessage(LogChannel channel, LogLevel level, string message)
        {
            if (!IsLogChannelSupported(channel))
            {
                return;
            }

            message = CreateMessage(channel, message);
            SendMessageToTargets(level, message);
        }

        private bool IsLogChannelSupported(LogChannel logChannel) =>
            Array.IndexOf(_settings.UnsupportedChannels, logChannel) == -1;

        private void SendMessageToTargets(LogLevel level, string message)
        {
            foreach (var target in _targets)
            {
                target.ApplyLog(level, message);
            }
        }

        private string CreateMessage(LogChannel channel, string message)
        {
            var messageBuilder = new StringBuilder();

            if (_settings.ShowTime)
            {
                messageBuilder.Append($"[{GetTimeString()}] ");
            }

            if (channel != LogChannel.None)
            {
                messageBuilder.Append($"{channel} ");
            }

            messageBuilder.Append(string.IsNullOrWhiteSpace(message) ? _settings.NullArgMarker : message);

            return messageBuilder.ToString();
        }

        private string GetTimeString() =>
            DateTime.Now.ToString(_settings.TimeFormat);
    }
}
