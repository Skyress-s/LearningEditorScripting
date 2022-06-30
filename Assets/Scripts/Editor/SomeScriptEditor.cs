using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// ref https://learn.unity.com/tutorial/editor-scripting#5c7f8528edbc2a002053b5fa

[CustomEditor(typeof(SomeScript))]
public class SomeScriptEditor : Editor
{
    public override void OnInspectorGUI() {
        SomeScript MySomeScript = (SomeScript)target;
        
        DrawDefaultInspector();

        EditorGUILayout.LabelField("Level", (MySomeScript.experience / MySomeScript.expPerLevel).ToString());

        MySomeScript.someValue = EditorGUILayout.IntField("SomeValue", MySomeScript.someValue);
        
        EditorGUILayout.HelpBox("This is a helpbox!", MessageType.Info);

        
        if (GUILayout.Button("Press for Debug a Message")) {
            Debug.Log("someText");
        }

        GUILayoutOption[] args = new GUILayoutOption[] {
            GUILayout.Width(200)
        };
        
        if (GUILayout.Button("Press for Debug another Message", args)) {
            Debug.Log("Another someText");
        }
    }
}
