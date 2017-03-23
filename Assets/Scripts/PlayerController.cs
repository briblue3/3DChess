using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public string playerID;
	public int score;

	// Use this for initialization
	void Start () {
		if (!isServer) {
			playerID = "black";
		} else {
			playerID = "white";
			Debug.Log (playerID);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void playerScore(string capturedPiece) {
		if (capturedPiece == "pawn") {
			score += 1;
		} else if (capturedPiece == "knight" || capturedPiece == "bishop") {
			score += 3;
		} else if (capturedPiece == "rook") {
			score += 5;
		} else if (capturedPiece == "queen") {
			score += 9;
		}
	}
}
