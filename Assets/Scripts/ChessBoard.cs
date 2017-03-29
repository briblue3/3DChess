using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class ChessBoard : MonoBehaviour {

	public GameObject squareWhite;
	public GameObject squareBlack;

	public GameObject player1;
	public GameObject player2;

	// white pieces
	public GameObject whitePawn;
	public GameObject whiteRook;
	public GameObject whiteKnight;
	public GameObject whiteBishop;
	public GameObject whiteQueen;
	public GameObject whiteKing;

	// black pieces
	public GameObject blackPawn;
	public GameObject blackRook;
	public GameObject blackKnight;
	public GameObject blackBishop;
	public GameObject blackQueen;
	public GameObject blackKing;


	public GameObject manager;

	private float x, y, z;
	private List<GameObject> boardSquares;
	private const int SCALE_FACTOR = 2;
	private const int BOARD_OFFSET = 8;		// number cols * scale / 2

	public GameObject currentPlayer;
	public string color;

	private Vector3 screenPoint;	// where clicked
	private Vector3 offset;

	// Use this for initialization
	public void Start (){

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
					squareGameObject.transform.parent = this.transform;
				} else {
					squareGameObject = (GameObject)Instantiate (squareBlack, new Vector3 (x, y, z), transform.rotation);
					squareGameObject.transform.parent = this.transform;
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

		//TakeTurns (false, 1);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Pieces(List<GameObject> boardSquares) {

		for (int i = 0; i < boardSquares.Count; i++) {

			GameObject b = boardSquares [i];

			float newX = b.GetComponent<Square> ().transform.position.x;
			float newY = 1.2f;
			float newZ = b.GetComponent<Square> ().transform.position.z;
			if ((b.GetComponent<Square> ().ColID == 'a' || b.GetComponent<Square> ().ColID == 'h') && (b.GetComponent<Square> ().RowID == 1 || b.GetComponent<Square>().RowID == 8)) {
				if (b.GetComponent<Square>().RowID == 1) {
					GameObject wRook = (GameObject)Instantiate (whiteRook, new Vector3 (newX, newY, newZ), transform.rotation);
					wRook.GetComponent<Pieces>().startPos = new Vector3 (newX, newY, newZ);
//					wRook.GetComponent<Pieces> ().setSquare (b.GetComponent<Square> ().ColID, b.GetComponent<Square> ().RowID);
				} else {
					GameObject bRook = (GameObject)Instantiate (blackRook, new Vector3 (newX, newY, newZ), transform.rotation);
					bRook.GetComponent<Pieces>().startPos = new Vector3 (newX, newY, newZ);
//					bRook.GetComponent<Pieces> ().setSquare (b.GetComponent<Square> ().ColID, b.GetComponent<Square> ().RowID);
				}
			} else if ((b.GetComponent<Square> ().ColID == 'b' || b.GetComponent<Square> ().ColID == 'g') && (b.GetComponent<Square> ().RowID == 1 || b.GetComponent<Square>().RowID == 8)) {
				if (b.GetComponent<Square>().RowID == 1) {
					GameObject wKnight = (GameObject)Instantiate (whiteKnight, new Vector3 (newX, newY, newZ), transform.rotation);
					wKnight.GetComponent<Pieces>().startPos = new Vector3 (newX, newY, newZ);
//					wKnight.GetComponent<Pieces> ().setSquare (b.GetComponent<Square> ().ColID, b.GetComponent<Square> ().RowID);
				} else {
					GameObject bKnight = (GameObject)Instantiate (blackKnight, new Vector3 (newX, newY, newZ), transform.rotation);
					bKnight.GetComponent<Pieces>().startPos = new Vector3 (newX, newY, newZ);
//					bKnight.GetComponent<Pieces> ().setSquare (b.GetComponent<Square> ().ColID, b.GetComponent<Square> ().RowID);
				}
			} else if ((b.GetComponent<Square> ().ColID == 'c' || b.GetComponent<Square> ().ColID == 'f') && (b.GetComponent<Square> ().RowID == 1 || b.GetComponent<Square>().RowID == 8)) {
				if (b.GetComponent<Square>().RowID == 1) {
					GameObject wBishop = (GameObject)Instantiate (whiteBishop, new Vector3 (newX, newY, newZ), transform.rotation);
					wBishop.GetComponent<Pieces>().startPos = new Vector3 (newX, newY, newZ);
//					wBishop.GetComponent<Pieces> ().setSquare (b.GetComponent<Square> ().ColID, b.GetComponent<Square> ().RowID);
				} else {
					GameObject bBishop = (GameObject)Instantiate (blackBishop, new Vector3 (newX, newY, newZ), transform.rotation);
					bBishop.GetComponent<Pieces>().startPos = new Vector3 (newX, newY, newZ);
//					bBishop.GetComponent<Pieces> ().setSquare (b.GetComponent<Square> ().ColID, b.GetComponent<Square> ().RowID);
				}
			} else if ((b.GetComponent<Square> ().ColID == 'd') && (b.GetComponent<Square> ().RowID == 1 || b.GetComponent<Square>().RowID == 8)) {
				if (b.GetComponent<Square>().RowID == 1) {
					GameObject wQueen = (GameObject)Instantiate (whiteQueen, new Vector3 (newX, newY, newZ), transform.rotation);
					wQueen.GetComponent<Pieces>().startPos = new Vector3 (newX, newY, newZ);
//					wQueen.GetComponent<Pieces> ().setSquare (b.GetComponent<Square> ().ColID, b.GetComponent<Square> ().RowID);
				} else {
					GameObject bKing = (GameObject)Instantiate (blackKing, new Vector3 (newX, newY, newZ), transform.rotation);
					bKing.GetComponent<Pieces>().startPos = new Vector3 (newX, newY, newZ);
//					bKing.GetComponent<Pieces> ().setSquare (b.GetComponent<Square> ().ColID, b.GetComponent<Square> ().RowID);
				}
			} else if ((b.GetComponent<Square> ().ColID == 'e') && (b.GetComponent<Square> ().RowID == 1 || b.GetComponent<Square>().RowID == 8)) {
				if (b.GetComponent<Square>().RowID == 1) {
					GameObject wKing = (GameObject)Instantiate (whiteKing, new Vector3 (newX, newY, newZ), transform.rotation);
					wKing.GetComponent<Pieces>().startPos = new Vector3 (newX, newY, newZ);
//					wKing.GetComponent<Pieces> ().setSquare (b.GetComponent<Square> ().ColID, b.GetComponent<Square> ().RowID);
				} else {
					GameObject bQueen = (GameObject)Instantiate (blackQueen, new Vector3 (newX, newY, newZ), transform.rotation);
					bQueen.GetComponent<Pieces>().startPos = new Vector3 (newX, newY, newZ);
//					bQueen.GetComponent<Pieces> ().setSquare (b.GetComponent<Square> ().ColID, b.GetComponent<Square> ().RowID);
				}
			} else if (b.GetComponent<Square> ().RowID == 2) {
				GameObject wPawn = (GameObject)Instantiate (whitePawn, new Vector3 (newX, newY, newZ), transform.rotation);
				wPawn.GetComponent<Pieces>().startPos = new Vector3 (newX, newY, newZ);
//				wPawn.GetComponent<Pieces> ().setSquare (b.GetComponent<Square> ().ColID, b.GetComponent<Square> ().RowID);
			} else if (b.GetComponent<Square> ().RowID == 7) {
				GameObject bPawn = (GameObject)Instantiate (blackPawn, new Vector3 (newX, newY, newZ), transform.rotation);
				bPawn.GetComponent<Pieces>().startPos = new Vector3 (newX, newY, newZ);
//				bPawn.GetComponent<Pieces> ().setSquare (b.GetComponent<Square> ().ColID, b.GetComponent<Square> ().RowID);
			}
		}
	}

	public void TakeTurns (bool gameover, int turn) {

		while (gameover == false) {
			bool logged = false;
			if (turn % 2 != 0) {
				// white turn
				currentPlayer = player1;
				color = "white";
				Camera.main.transform.position = new Vector3(11.0f, 12.0f, -12.0f);
				Camera.main.transform.rotation = Quaternion.Euler (45.0f, 0.0f, 0.0f);
				while (currentPlayer.GetComponent<PlayerController> ().hasMoved () == false) {
					if (currentPlayer.GetComponent<PlayerController> ().hasMoved () == true) {
						break;
					}
				}
			} else if (turn % 2 == 0) {
				// black turn
				currentPlayer = player2;
				color = "black";
				Camera.main.transform.position = new Vector3(9.0f, 12.0f, 13.0f);
				Camera.main.transform.rotation = Quaternion.Euler (45.0f, 180.0f, 0.0f);
			}
			turn++;
			gameover = true;
		}
	}
		

}