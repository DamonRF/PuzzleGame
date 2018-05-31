using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzle : MonoBehaviour {

    public int form = 1;
    private int correctForm = 0;
    public bool correctPlace = false;
    public GameObject manager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartPuzzle()
    {
        form = 1;
        GetComponent<SpriteRenderer>().color = Color.white;
        correctForm = Random.Range(1, 5);
        if (form == correctForm)
        {
            correctPlace = true;
        }
        else
        {
            correctPlace = false;
        }
    }

    public void ChangePiece()
    {
        form++;
        if (form >= 4)
        {
            form = 1;
        }

        if (form == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        } else if (form == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        } else if (form == 3)
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
        } else if (form == 4)
        {
            GetComponent<SpriteRenderer>().color = new Color(143, 0, 254);
        }

        if (form == correctForm)
        {
            correctPlace = true;
        } else
        {
            correctPlace = false;
        }
    }
}
