using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector2 scrollPosition;
	public string longString = "This is a long-ish string";

	void OnGUI() {
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(100), GUILayout.Height(100));
		GUILayout.Label(longString);
		if (GUILayout.Button("Clear"))
			longString = "";

		GUILayout.EndScrollView();
		if (GUILayout.Button("Add More Text"))
			longString += "\nHere is another line";

	}
}
