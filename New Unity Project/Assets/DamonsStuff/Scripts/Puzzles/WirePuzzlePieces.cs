using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzlePieces : MonoBehaviour {
    public GameObject director;
    public int correctPosition;
    public int maxPosition;
    public bool rightPosition = false;
    int position = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RotateMe()
    {
        this.gameObject.transform.rotation = new Quaternion(0, 0, 0, w: +90);
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
    }
}
