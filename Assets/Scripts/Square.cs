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

		if (false) {
			piece.transform.position = new Vector3 (this.transform.position.x, piece.transform.position.y, this.transform.position.z);
			piece.GetComponent<Pieces> ().setSquare (this.ColID, this.RowID);
			piece.GetComponent<Pieces>().startPos = piece.transform.position;
		} else {
			piece.transform.position = piece.GetComponent<Pieces>().startPos;
		}
	}


}
