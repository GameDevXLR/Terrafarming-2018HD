using UnityEngine;
using UnityEditor;

using UnityEditor.SceneManagement;


[CustomEditor(typeof(CameraController))]
public class CameraControllerEditor : Editor {

    CameraController cam;

    public GameObject obj = null;


    SerializedProperty distanceProperty;
    SerializedProperty horizontalProperty;
    SerializedProperty verticalProperty;
    SerializedProperty zoomStepProperty;
    SerializedProperty zoomMinimalProperty;
    SerializedProperty zoomMaxProperty;
    SerializedProperty verticalTextProperty;
    SerializedProperty horizontalTextProperty;
    SerializedProperty smoothProperty;
    SerializedProperty focusProperty;
    SerializedProperty radiusDetectProperty;
    SerializedProperty heigthDetectProperty;
    SerializedProperty maskProperty;
    SerializedProperty minHeightProperty;
    SerializedProperty blockByEnvProperty;
    SerializedProperty focusYAddProperty;
    SerializedProperty rangeYProperty;


    private void OnEnable()
    {
        cam = (CameraController)target;
        


        if (!Application.isPlaying)
        {
            //cam.moveCam();
        }
        distanceProperty = serializedObject.FindProperty("distance");
        horizontalProperty = serializedObject.FindProperty("h");
        verticalProperty = serializedObject.FindProperty("v");
        zoomMinimalProperty = serializedObject.FindProperty("minDistance");
        zoomMaxProperty = serializedObject.FindProperty("maxDistance");
        zoomStepProperty = serializedObject.FindProperty("stepZoom");
        verticalTextProperty = serializedObject.FindProperty("verticalText");
        horizontalTextProperty = serializedObject.FindProperty("horizontalText");
        smoothProperty = serializedObject.FindProperty("smooth");
        focusProperty = serializedObject.FindProperty("focus");
        radiusDetectProperty = serializedObject.FindProperty("radiusDetect");
        heigthDetectProperty = serializedObject.FindProperty("heigthDetect");
        maskProperty = serializedObject.FindProperty("mask");
        minHeightProperty = serializedObject.FindProperty("minHeight");
        blockByEnvProperty = serializedObject.FindProperty("blocByEnv");
        focusYAddProperty = serializedObject.FindProperty("focusYAdd");
        rangeYProperty = serializedObject.FindProperty("rangeY");

    }

    public override void OnInspectorGUI()
    {

        serializedObject.Update();

        distanceProperty.floatValue = EditorGUILayout.Slider("Distance", cam.Distance, cam.minDistance, cam.maxDistance);
        ////cam.H = EditorGUILayout.Slider("Horizontal angle", cam.H, 0, 360);
        verticalProperty.floatValue = EditorGUILayout.Slider("Vertical angle", cam.V, cam.minY, cam.maxY);
        horizontalProperty.floatValue = EditorGUILayout.Slider("Horizontal angle", cam.H, cam.minX, cam.maxX);

        EditorGUILayout.PropertyField(focusProperty);
        EditorGUILayout.PropertyField(zoomMinimalProperty);
        EditorGUILayout.PropertyField(zoomMaxProperty);
        EditorGUILayout.PropertyField(zoomStepProperty);
        EditorGUILayout.PropertyField(smoothProperty);
        EditorGUILayout.PropertyField(verticalTextProperty);
        EditorGUILayout.PropertyField(horizontalTextProperty);
        EditorGUILayout.PropertyField(heigthDetectProperty);
        EditorGUILayout.PropertyField(radiusDetectProperty);
        EditorGUILayout.PropertyField(maskProperty);
        EditorGUILayout.PropertyField(minHeightProperty);
        EditorGUILayout.PropertyField(blockByEnvProperty);
        EditorGUILayout.PropertyField(focusYAddProperty);

        if (!Application.isPlaying && cam.focus != null )
        {
            cam.MoveSmoothlyCam();
            cam.RotateSmoothlyCam();
        }

        serializedObject.ApplyModifiedProperties();
    }

}
