using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GenerateLevelView))]
public class GeneratorLevelEditor : Editor
{
    private GenerateLevelController _generateLevelController;

    private void OnEnable()
    {
        var generateLevelView = (GenerateLevelView)target;
        _generateLevelController = new GenerateLevelController(generateLevelView);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var tileMap = serializedObject.FindProperty("_tileMapGround");
        EditorGUILayout.PropertyField(tileMap);

        if (GUI.Button(new Rect(10, 0, 60, 50), "Generate"))
        {
            _generateLevelController.GenerateLevel();
        }

        if (GUI.Button(new Rect(10, 55, 60, 50), "Clear"))
        {
            _generateLevelController.ClearTilemap();
        }

        GUILayout.Space(100);

        serializedObject.ApplyModifiedProperties();
    }
}
