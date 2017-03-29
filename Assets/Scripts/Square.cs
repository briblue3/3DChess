using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Square : MonoBehaviour {

	public string Color { get; set; }	// putting private before get/set will make it only accessible/changeable from w/in the class
	public int RowID { get; set; }		// get & set make these class properties and not just random public variables
	public char ColID { get; set; }
	public bool mouseDown = false;

	// private GamePiece currentGamePiece

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider piece) {
		if (!Input.GetMouseButtonDown (0) && !Input.GetMouseButton(0)) {
			if (piece.name == "Knight" || piece.name == "Rook" || piece.name == "Bishop" || piece.name == "King" || piece.name == "Pawn" || piece.name == "Queen"){
				Debug.Log ("triggered");
			}
		}
		piece.transform.position = new Vector3 (this.transform.position.x, piece.transform.position.y, this.transform.position.z);

		if (piece.name == "Knight") {
			piece.GetComponent<Knight> ().setSquare (this.ColID, this.RowID);
		} else if (piece.name == "Rook") {
			piece.GetComponent<Rook> ().setSquare (this.ColID, this.RowID);
		} else if (piece.name == "Bishop") {
			piece.GetComponent<Bishop> ().setSquare (this.ColID, this.RowID);
		} else if (piece.name == "King") {
			piece.GetComponent<King> ().setSquare (this.ColID, this.RowID);
		} else if (piece.name == "Pawn") {
			piece.GetComponent<Pawn> ().setSquare (this.ColID, this.RowID);
		} else if (piece.name == "Queen") {
			piece.GetComponent<Queen> ().setSquare (this.ColID, this.RowID);
		}
	}


}
