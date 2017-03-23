using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChessBoard : MonoBehaviour {

	public GameObject squareWhite;
	public GameObject squareBlack;

	// white pieces
	public GameObject whitePawn;
	public GameObject whiteRook;
	public GameObject whiteKnight;
	public GameObject whiteBishop;
	public GameObject whiteQueen;
	public GameObject whiteKing;

//	// black pieces
//	public GameObject blackPawn;
//	public GameObject whiteRook;
//	public GameObject whiteKnight;
//	public GameObject whiteBishop;
//	public GameObject whiteQueen;
//	public GameObject whiteKing;
//
	private float x, y, z;
	private List<GameObject> boardSquares;
	private const int SCALE_FACTOR = 2;
	private const int BOARD_OFFSET = 8;		// number cols * scale / 2

	// Use this for initialization
	void Start (){
		x = 0f;
		y = 1f;
		z = 0f;

		boardSquares = new List<GameObject> ();

		int row = 1;
		int col = 1;
		int switchInitColor = 0;

		for (int i = 1; i <= 8; i++) {
			col = 1;
			for (int j = 1; j <= 8; j++) {
				z = (float)(row * SCALE_FACTOR - BOARD_OFFSET);
				x = (float)(col * SCALE_FACTOR);

				GameObject squareGameObject;
				if ((col % 2) == switchInitColor) {
					squareGameObject = (GameObject)Instantiate (squareWhite, new Vector3 (x, y, z), transform.rotation);
				} else {
					squareGameObject = (GameObject)Instantiate (squareBlack, new Vector3 (x, y, z), transform.rotation);
				}

				boardSquares.Add (squareGameObject);
				Square squareObj = squareGameObject.GetComponent<Square> ();
				squareObj.RowID = row;
				squareObj.ColID = (char)(col + 96);
//				Debug.Log (row);
//				Debug.Log (col);
				col++;
			}
			if (switchInitColor == 0) {
				switchInitColor = 1;
			} else {
				switchInitColor = 0;
			}

			row++;
		}

		Pieces (boardSquares);

		TakeTurns (false, 1);
	}

	// Update is called once per frame
	void Update () {

	}

//	void Pieces() {
//		for (int i = 1; i <= 8; i++) {
//			for (char j = 'a'; j <= 'h'; j++) {
//				if (i == 1) {
//					if (j == 'a' || j == 'h') {
//						// white rook
//						GameObject wRook = (GameObject)Instantiate(whiteRook, new Vector3(
//					} else if (j == 'b' || j == 'g') {
//						// white knight
//					} else if (j == 'c' || j == 'f') {
//						// white bishop
//					} else if (j == 'd') {
//						// white queen
//					} else {
//						// white king 
//					}
//				} else if (i == 2) {
//					// white pawn
//				} else if (i == 7) {
//					// black pawn
//				} else if (i == 8) {
//					if (j == 'a' || j == 'h') {
//						// black rook
//					} else if (j == 'b' || j == 'g') {
//						// black knight
//					} else if (j == 'c' || j == 'f') {
//						// black bishop
//					} else if (j == 'd') {
//						// black king
//					} else {
//						// black queen
//					}
//				}
//			}
//		}
//	}

	void Pieces(List<GameObject> boardSquares) {

		for (int i = 0; i < boardSquares.Count; i++) {

			GameObject b = boardSquares [i];

			float newX = b.GetComponent<Square> ().transform.position.x + 1.0f;
			float newY = 1.65f;
			float newZ = b.GetComponent<Square> ().transform.position.z - 1.0f;

			if (b.GetComponent<Square>().RowID > 4) {
				newX = boardSquares [i].GetComponent<Square> ().transform.position.x - 1.0f;
			}
//			if (b.GetComponent<Square>().ColID > 'd') {
//				newZ = 
		
			if ((b.GetComponent<Square> ().ColID == 'a' || b.GetComponent<Square> ().ColID == 'h') && b.GetComponent<Square> ().RowID == 1) {
				GameObject wRook = (GameObject)Instantiate (whiteRook, new Vector3 (newX, newY, newZ), transform.rotation);
			} else if ((b.GetComponent<Square> ().ColID == 'b' || b.GetComponent<Square> ().ColID == 'g') && b.GetComponent<Square> ().RowID == 1) {
				GameObject wKnight = (GameObject)Instantiate (whiteKnight, new Vector3 (newX, newY, newZ), transform.rotation);
			} else if ((b.GetComponent<Square> ().ColID == 'c' || b.GetComponent<Square> ().ColID == 'f') && b.GetComponent<Square> ().RowID == 1) {
				GameObject wBishop = (GameObject)Instantiate (whiteBishop, new Vector3 (newX, newY, newZ), transform.rotation);
			} else if (b.GetComponent<Square> ().ColID == 'd' && b.GetComponent<Square> ().RowID == 1) {
				GameObject wQueen = (GameObject)Instantiate (whiteQueen, new Vector3 (newX, newY, newZ), transform.rotation);
			} else if (b.GetComponent<Square> ().ColID == 'e' && b.GetComponent<Square> ().RowID == 1) {
				GameObject wKing = (GameObject)Instantiate (whiteKing, new Vector3 (newX, newY, newZ), transform.rotation);
			} else if (b.GetComponent<Square> ().RowID == 2) {
				GameObject wPawn = (GameObject)Instantiate (whitePawn, new Vector3 (newX, newY, newZ), transform.rotation);
			}
		}
	}

	void TakeTurns (bool gameover, int turn) {
		while (gameover == false) {
			if (turn % 2 != 0) {
				// white turn
				Camera.main.transform.position = new Vector3(11.0f, 12.0f, -12.0f);
				Camera.main.transform.rotation = Quaternion.Euler (45.0f, 0.0f, 0.0f);
			} else if (turn % 2 == 0) {
				// black turn
				Camera.main.transform.position = new Vector3(9.0f, 12.0f, 13.0f);
				Camera.main.transform.rotation = Quaternion.Euler (45.0f, 180.0f, 0.0f);
			}
			turn++;
			gameover = true;
		}
	}
}