using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace MIG.Editor.PropertyDrawers
{
    [SingletonData(
            savePath: "Library/CheckObjectAttributeSettings.asset",
            settingsPath: "Preferences/Check Object Attribute Settings")]
    internal sealed class CheckObjectPropertyDrawerSettings : SavedScriptableSingleton<CheckObjectPropertyDrawerSettings>
    {
        [SerializeField]
        private Color _validColor = Color.green;
        [SerializeField]
        private Color _invalidColor = Color.red;

        public Color ValidColor => _validColor;
        public Color InvalidColor => _invalidColor;

        [SettingsProvider]
        [UsedImplicitly]
        private static SettingsProvider GetProvider() => GetSingletonSettingsProvider();
    }
}
