using System.Collections;
using System.Collections.Generic;
using UnityEditor;


[CustomEditor (typeof (MapGenerator))]
public class EditorMapGenerate : Editor
{
    public override void OnInspectorGUI()
    { 
        MapGenerator mapgen = (MapGenerator)target;
        if (DrawDefaultInspector())
        {
            if (mapgen.autoUpdate)
            {
                mapgen.GenerateMap();
            }
        }

        if (UnityEngine.GUILayout.Button("Generate"))
        {
            mapgen.GenerateMap();

        }
    }
}
