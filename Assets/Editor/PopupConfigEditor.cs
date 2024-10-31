using Scripts.Configs;
using UnityEditor;
using UnityEngine;
using System;

namespace Editor
{
    [CustomEditor(typeof(PopupConfig))]
    public class PopupConfigEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var popupConfig = (PopupConfig)target;

            if (popupConfig.GoodsData.Length > 6)
                Array.Resize( ref  popupConfig.GoodsData, 6);

            if (GUI.changed)
                EditorUtility.SetDirty(popupConfig);
        }
    }
}