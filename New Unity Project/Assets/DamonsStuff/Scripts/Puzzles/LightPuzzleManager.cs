using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzleManager : MonoBehaviour {

    public GameObject[] pieces;
    public bool[] trueOrFalse;
    public StringArray[] conversation;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Chances", 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateTrueOrFalse(bool rightForm, GameObject piece)
    {
        int place = 0;
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i] == piece)
            {
                place = i;
                break;
            }
        }
        if (rightForm)
        {
            trueOrFalse[place] = true;
        }
        else
        {
            trueOrFalse[place] = false;
        }
        
    }

    public void CheckPieces()
    {
        int correct = 0;
        for (int i = 0; i < trueOrFalse.Length; i++)
        {
            if (trueOrFalse[i])
            {
                correct++;
            }
        }

        conversation[0].conversation[0] = correct + " are correct.";
        if (correct >= pieces.Length){
            conversation[0].conversation[1] = "All light pieces are correct";
        } else
        {
            PlayerPrefs.SetInt("Chances", PlayerPrefs.GetInt("Chances") - 1);
            if (PlayerPrefs.GetInt("Chances") <= 0)
            {
                PlayerPrefs.SetInt("Chances", 10);
                conversation[0].conversation[1] = "No more chances. Puzzle reseting";
                for (int i = 0; i < pieces.Length; i++)
                {
                    pieces[i].GetComponent<LightPuzzle>().RestartPuzzle();
                }
            } else
            {
                conversation[0].conversation[1] = PlayerPrefs.GetInt("Chances") + " chances remaining";
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            CheckPieces();
            collision.gameObject.GetComponent<Interact>().TransferLightPuzzleInfo(this.gameObject);
        }
    }
}
