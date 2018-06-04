using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzle : MonoBehaviour {

    public int form = 1;
    private int correctForm = 0;
    public bool correctPlace = false;
    public GameObject manager;
    public bool isSolved = false;
	// Use this for initialization
	void Start () {
        RestartPuzzle();
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
        //Debug.Log(gameObject.name + " is " + correctForm);
        manager.GetComponent<LightPuzzleManager>().UpdateTrueOrFalse(correctPlace, this.gameObject);
    }

    public void ChangePiece()
    {
        form++;
        if (form >= 5)
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

        manager.GetComponent<LightPuzzleManager>().UpdateTrueOrFalse(correctPlace, this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("I'm in " + this.gameObject.name);
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !isSolved)
        {
            ChangePiece();
        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Left " + this.gameObject.name);
    }*/
}
