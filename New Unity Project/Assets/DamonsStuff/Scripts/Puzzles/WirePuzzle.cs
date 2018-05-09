using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzle : MonoBehaviour {
    public BoolArray correctPlaces;
    public GameObject[] pieces;
	// Use this for initialization
	void Start () {
        GameObject[] addPieces = GameObject.FindGameObjectsWithTag("Piece");
        pieces = addPieces;
        
        for (int i = 0; i < pieces.Length; i++)
        {
            correctPlaces.trueOrFalse[i] = pieces[i].GetComponent<WirePuzzlePieces>().rightPosition;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
