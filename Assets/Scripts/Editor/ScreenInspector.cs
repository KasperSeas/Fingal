using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScreenQuad))]
public class ScreenInspector : Editor {

	ScreenQuad screen;

	void OnEnable () {
		screen = (ScreenQuad)target;


	}

	public override void OnInspectorGUI(){
		GUILayout.Label (screen.name);
		GUILayout.Space (20);
		base.OnInspectorGUI ();
	}
	

}
