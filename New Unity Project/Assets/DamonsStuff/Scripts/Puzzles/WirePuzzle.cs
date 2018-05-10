using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzle : MonoBehaviour {
    public BoolArray correctPlaces;
    public GameObject[] pieces;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < pieces.Length; i++)
        {
            correctPlaces.trueOrFalse[i] = pieces[i].GetComponent<WirePuzzlePieces>().rightPosition;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdatePlaces(bool rightPlace, GameObject piece)
    {
        int place = 0;
        for (int i = 0; i < pieces.Length; i++)
        {
            if(pieces[i] == piece)
            {
                place = i;
                break;
            }
        }
        if (rightPlace)
        {
            correctPlaces.trueOrFalse[place] = true;
        } else
        {
            correctPlaces.trueOrFalse[place] = false;
        }
        for (int i = 0; i < correctPlaces.trueOrFalse.Length; i++)
        {
            if (!correctPlaces.trueOrFalse[i])
            {
                Debug.Log("Incorrect");
                return;
            }
        }
        Debug.Log("You win!");
    }
}
