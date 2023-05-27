using MIG.API;
using System;

namespace MIG.Logging
{
    [Serializable]
    public sealed class LogServiceSettings
    {
        public bool ShowTime;
        public string TimeFormat;
        public LogChannel[] UnsupportedChannels;
        public string NullArgMarker;
    }
}
