using MIG.API;
using UnityEngine;

namespace MIG.Logging
{
    public sealed class UnityLogTarget : ILogTarget
    {
        public void ApplyLog(LogLevel logLevel, string message)
        {
            Debug.unityLogger.Log(logLevel.ToUnityLogType(), message);
        }
    }
}
