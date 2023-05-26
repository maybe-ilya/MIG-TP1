using MIG.API;
using UnityEngine;
using UnityEditor;

namespace MIG.Editor
{
    public static class EditorGUIExtensions
    {
        public static void DrawPropertyFieldOnlyTooltip(this SerializedProperty property, Rect rect, bool includeChildren = true)
        {
            var tooltip = property.displayName;
            if (property.tooltip.IsFilled())
            {
                tooltip += $" - {property.tooltip}";
            }

            EditorGUI.LabelField(rect, string.Empty.ToGUI(tooltip));
            EditorGUI.PropertyField(rect, property, GUIContent.none, includeChildren);
        }
    }
}
