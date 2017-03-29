using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunGame : MonoBehaviour {

	public GameObject board;	// ChessBoard prefab
	public GameObject chess;	// chess board

	// Use this for initialization
	void Start () {
		chess = (GameObject)Instantiate (board, new Vector3 (0, 0, 0), transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
