namespace MIG.API
{
    public interface ILogTarget
    {
        void ApplyLog(LogLevel logLevel, string message);
    }
}
