using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HairController))]
public class HairControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        DrawDefaultInspector();
        HairController cc = (HairController)target;
        if (GUILayout.Button("Create Characters"))
        {
            cc.ChangeFace ();
            cc.ChangeHair ();
        }
    }
}
