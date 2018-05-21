using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzlePieces : MonoBehaviour {
    public GameObject director;
    public int correctPosition;
    public int maxPosition;
    public int currentPosition;
    public bool rightPosition = false;
    int position = 1;
	// Use this for initialization
	void Start () {
        position = currentPosition;
        if(position <= 0)
        {
            position = 1;
        }
        /*if (position == correctPosition)
        {
            director.GetComponent<WirePuzzle>().UpdatePlaces(rightPosition, this.gameObject);
        }*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //Pointing up is 1
    //Pointing left is 2
    //Pointing down is 3
    //Pointing right is 4


    public void RotateMe()
    {
        this.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 1), 90);
        position += 1;
        if (position > maxPosition)
        {
            position = 1;
        }
        if (position == correctPosition)
        {
            rightPosition = true;
        } else
        {
            rightPosition = false;
        }
        director.GetComponent<WirePuzzle>().UpdatePlaces(rightPosition, this.gameObject);
    }
}
