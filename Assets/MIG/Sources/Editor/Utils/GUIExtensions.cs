using UnityEngine;
using UnityEditor;

namespace MIG.Editor
{
    public static class GUIExtensions
    {
        public static GUIContent ToGUI(this string text) => 
            new GUIContent(text);

        public static GUIContent ToGUI(this string text, string tooltip) => 
            new GUIContent(text, tooltip);

        public static string ToNice(this string text) => 
            ObjectNames.NicifyVariableName(text);

        public static GUIContent ToNiceGUI(this string text) => 
            text.ToNice().ToGUI();
    }
}
