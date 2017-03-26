using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour {


	private Vector3 screenPoint;	// where clicked
	private Vector3 offset;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		Debug.Log ("Clicked");
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(mousePosition);
	}

	void OnMouseDrag(){
		Vector3 mousePoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousePoint) + offset;
		transform.position = mousePosition;
	}
}
