﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceType {Pawn, Rook, Knight, Bishop, Queen, King, None}
public enum PieceColor {Black, White}

public class Pieces : MonoBehaviour {

	private Vector3 screenPoint;    // where clicked
	private Vector3 offset;
	private float y = 2.24f;

	public string PieceName;
	public Vector3 startPos;
	public string startSquare;
	public string endSquare;
	public PieceType Type;
	public PieceColor Color;
	public char col;
	public int row;

	void OnMouseDown(){
		this.GetComponent<BoxCollider> ().enabled = false;
		Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(mouse);
	}

	void OnMouseDrag() {
		this.GetComponent<BoxCollider> ().enabled = false;
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		curPosition.y = 3f;
		transform.position = curPosition;

		Plane plane = new Plane (Vector3.up, new Vector3 (0, 3, 0));
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float distance;
		if (plane.Raycast (ray, out distance)) {
			transform.position = ray.GetPoint (distance);
		}
	}

	void OnMouseUp() {
		this.GetComponent<BoxCollider> ().enabled = true;
		float posX = Mathf.RoundToInt (this.transform.transform.position.x);
		float posZ = Mathf.RoundToInt (this.transform.transform.position.z);

		if (posX >= 2.0f && posX <= 16.0f) {
			if (posX % 2.0f != 0 && posX < this.transform.transform.position.x) {
				posX++;
			} else if (posX % 2.0f != 0 && posX > this.transform.transform.position.x) {
				posX--;
			}
		} else {
			if (posX < 2.0f) {
				posX = 2.0f;
			} else if (posX > 16.0f) {
				posX = 16.0f;
			}
		}
		if (posZ >= -6.0f && posZ <= 8.0f) {
			if (posZ % 2.0f != 0 && posZ < this.transform.transform.position.z) {
				posZ++;
			} else if (posZ % 2.0f != 0 && posZ > this.transform.transform.position.z) {
				posZ--;
			}
		} else {
			if (posZ < -6.0f) {
				posZ = -6.0f;
			} else if (posZ > 8.0f) {
				posZ = 8.0f;
			}
		}
	
		this.transform.position = new Vector3 (posX, y, posZ);
		Debug.Log (posX.ToString() + " " + posZ.ToString());
	}

	public void setSquare(char col, int row) {
		this.col = col;
		this.row = row;
	}

//	void OnTriggerEnter (Collider otherPiece) {
//		if (this.CompareTag ("BlackPiece") && otherPiece.CompareTag ("WhitePiece")) {
//			Destroy (otherPiece);
//		} else if (this.CompareTag ("WhitePiece") && otherPiece.CompareTag ("BlackPiece")) {
//			Destroy (otherPiece);
//		}
//	}
}
