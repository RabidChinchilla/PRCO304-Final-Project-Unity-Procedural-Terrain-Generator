using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HeightMapSettings))]
public class HeightMapSettingsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        HeightMapSettings data = (HeightMapSettings)base.target;

        if (GUILayout.Button("Randomise Seed"))
        {
            data.noiseSettings.seed = Random.Range(0, 999999);
            data.NotifyOfUpdatedValues();
            EditorUtility.SetDirty(target);
        }

        if (GUILayout.Button("Update"))
        {
            data.NotifyOfUpdatedValues();
            EditorUtility.SetDirty(target);
        }
    }
}
