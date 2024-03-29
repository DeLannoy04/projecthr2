﻿using UnityEditor;
using UnityEngine;

namespace PlayerLevel.Editor
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect rect, SerializedProperty prop, GUIContent label)
        {
            var wasEnabled = GUI.enabled;
            GUI.enabled = false;
            EditorGUI.PropertyField(rect, prop);
            GUI.enabled = wasEnabled;
        }
    }
}