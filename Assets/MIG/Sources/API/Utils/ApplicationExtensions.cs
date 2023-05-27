using UnityEngine;
using System.Linq;

namespace MIG.API
{
    public static class ApplicationExtensions
    {
        public static bool IsDesktop =>
            CheckPlatform(RuntimePlatform.WindowsPlayer, RuntimePlatform.OSXPlayer, RuntimePlatform.LinuxPlayer);

        public static bool IsEditor =>
            CheckPlatform(RuntimePlatform.WindowsEditor, RuntimePlatform.OSXEditor, RuntimePlatform.LinuxEditor);

        private static bool CheckPlatform(params RuntimePlatform[] platforms) =>
            platforms.Any(platform => Application.platform == platform);
    }
}
