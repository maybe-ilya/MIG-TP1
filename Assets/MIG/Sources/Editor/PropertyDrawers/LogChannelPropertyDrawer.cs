using MIG.API;
using UnityEngine;
using UnityEditor;

namespace MIG.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(LogChannel))]
    internal sealed class LogChannelPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var propertyCopy = property.Copy();

            using var propertyScope = new EditorGUI.PropertyScope(position, label, property);
            var rect = EditorGUI.PrefixLabel(position, propertyScope.content);
            property.NextVisible(true);

            using var checkScope = new EditorGUI.ChangeCheckScope();
            EditorGUI.PropertyField(rect, property, GUIContent.none);
            var channelName = property.stringValue;

            if (checkScope.changed)
            {
                propertyCopy.boxedValue = new LogChannel(channelName);
            }
        }
    }
}
