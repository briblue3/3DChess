using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Square : MonoBehaviour {

	public string Color { get; set; }	// putting private before get/set will make it only accessible/changeable from w/in the class
	public int RowID { get; set; }		// get & set make these class properties and not just random public variables
	public char ColID { get; set; }
	public bool mouseDown = false;
	public bool hasPiece;

	// private GamePiece currentGamePiece

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider piece) {
		if (!Input.GetMouseButtonDown (0) && !Input.GetMouseButton(0)) {
			if (piece.name == "Knight" || piece.name == "Rook" || piece.name == "Bishop" || piece.name == "King" || piece.name == "Pawn" || piece.name == "Queen"){
				Debug.Log ("triggered");
			}
		}

		if (Network.TestConnection () == ConnectionTesterStatus.PublicIPIsConnectable) {
			if (ValidMove (piece)) {
				piece.transform.position = new Vector3 (this.transform.position.x, piece.transform.position.y, this.transform.position.z);
				piece.GetComponent<Pieces> ().setSquare (this.ColID, this.RowID);
				piece.GetComponent<Pieces> ().startPos = piece.transform.position;
				hasPiece = true;
			} else {
				piece.transform.position = piece.GetComponent<Pieces> ().startPos;
			}
		}
	}

	public bool ValidMove(Collider piece) {

		if (piece.name == "King") {
			// one square each direction, inc. diag.
			if ((Mathf.Abs (this.ColID - piece.GetComponent<Pieces> ().col) == 1 && this.RowID == piece.GetComponent<Pieces> ().row) ||
				(Mathf.Abs (this.RowID - piece.GetComponent<Pieces> ().row) == 1 && this.ColID == piece.GetComponent<Pieces> ().col) ||
				((Mathf.Abs (this.RowID - piece.GetComponent<Pieces> ().row) == 1) && (Mathf.Abs (this.ColID - piece.GetComponent<Pieces> ().col) == 1))) {
				return true;
			}
		} else if (piece.name == "Rook") {
			// any number of vacant horizontal or vertical
			if (this.RowID == piece.GetComponent<Pieces> ().row || this.ColID == piece.GetComponent<Pieces> ().col) {
				return true;
			}
		} else if (piece.name == "Bishop") {
			// any vacant diagonal
			if (Mathf.Abs (this.ColID - piece.GetComponent<Pieces> ().col) == Mathf.Abs (this.RowID - piece.GetComponent<Pieces> ().row)) {
				return true;
			}
		} else if (piece.name == "Queen") {
			// any vacant horizontal or vertical or diagonal
			if ((this.RowID == piece.GetComponent<Pieces> ().row || this.ColID == piece.GetComponent<Pieces> ().col) ||
				(Mathf.Abs (this.ColID - piece.GetComponent<Pieces> ().col) == Mathf.Abs (this.RowID - piece.GetComponent<Pieces> ().row))) {
				return true;
			}
		} else if (piece.name == "Knight") {
			// L shaped jump
			if (((Mathf.Abs (this.ColID - piece.GetComponent<Pieces> ().col) == 2) && (Mathf.Abs (this.RowID - piece.GetComponent<Pieces> ().row) == 1)) ||
				((Mathf.Abs (this.RowID - piece.GetComponent<Pieces> ().row) == 2) && (Mathf.Abs (this.ColID - piece.GetComponent<Pieces> ().col) == 1))) {
				return true;
			}
		} else if (piece.name == "Pawn") {
			// first move can be 2, else 1
			if (piece.GetComponent<Pieces>().CompareTag("BlackPiece") && piece.GetComponent<Pieces>().row == 7){
				if ((piece.GetComponent<Pieces> ().row - this.RowID == 2) || (piece.GetComponent<Pieces> ().row - this.RowID == 1)) {
					return true;
				} else if (piece.GetComponent<Pieces> ().row - this.RowID == 1) {
					return true;
				}
			} else if (piece.GetComponent<Pieces>().CompareTag("WhitePiece") && piece.GetComponent<Pieces>().row == 2){
				if ((this.RowID - piece.GetComponent<Pieces> ().row == 2) || (this.RowID - piece.GetComponent<Pieces> ().row == 1)) {
					return true;
				} else if (this.RowID - piece.GetComponent<Pieces> ().row == 1) {
					return true;
				}
			}
		}
		return false;
	}
}
