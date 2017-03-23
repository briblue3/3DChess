using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {

	public string Color { get; set; }	// putting private before get/set will make it only accessible/changeable from w/in the class
	public int RowID { get; set; }		// get & set make these class properties and not just random public variables
	public char ColID { get; set; }
	// private GamePiece currentGamePiece

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
