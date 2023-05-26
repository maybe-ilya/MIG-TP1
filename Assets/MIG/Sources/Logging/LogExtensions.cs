using MIG.API;
using System;
using UnityEngine;

namespace MIG.Logging
{
    public static class LogExtensions
    {
        public static LogType ToUnityLogType(this LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.INFO => LogType.Log,
                LogLevel.WARNING => LogType.Warning,
                LogLevel.ERROR => LogType.Error,
                _ => throw new NotImplementedException($"LogLevel {logLevel} doesn't have corresponding Unity LogType for now"),
            };
        }

        public static LogLevel ToLogLevel(this LogType logType)
        {
            return logType switch
            {
                LogType.Log => LogLevel.INFO,
                LogType.Warning => LogLevel.WARNING,
                LogType.Error => LogLevel.ERROR,
                _ => throw new NotImplementedException($"LogType {logType} doesn't have corresponding LogLevel for now"),
            };
        }
    }
}
