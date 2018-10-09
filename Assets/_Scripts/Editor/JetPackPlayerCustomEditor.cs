﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(JetPackSO))]
public class JetPackPlayerCustomEditor : Editor
{

    JetPackSO res;

    TerrainEnum terrains;


    private void OnEnable()
    {
        res = (JetPackSO)target;
        terrains = (TerrainEnum)res.TerrainsTest;
    }

    public override void OnInspectorGUI()
    {

        serializedObject.Update();
        //terrains = (TerrainEnum)EditorGUILayout.EnumMaskField("Terrains", enumValue: terrains);
        terrains = (TerrainEnum)EditorGUILayout.EnumFlagsField(terrains);
        //res.Terrain = terrains;
        res.TerrainsTest = (int)terrains;
        serializedObject.ApplyModifiedProperties();
        DrawDefaultInspector();
    }
}