using System;

namespace MIG.API
{
    public readonly struct LogChannel : IEquatable<LogChannel>
    {
        private readonly string _name;

        public LogChannel(string name)
        {
            _name = name;
        }

        public static readonly LogChannel None = new("[None]");

        public bool Equals(LogChannel other) =>
            _name.Equals(other._name, StringComparison.InvariantCulture);

        public override bool Equals(object obj) =>
            obj is LogChannel other && Equals(other);

        public override int GetHashCode() =>
            string.IsNullOrWhiteSpace(_name) ? 0 : _name.GetHashCode();

        public override string ToString() => _name;

        public static bool operator ==(LogChannel left, LogChannel right) => 
            left.Equals(right);

        public static bool operator !=(LogChannel left, LogChannel right) => 
            !left.Equals(right);
    }
}
