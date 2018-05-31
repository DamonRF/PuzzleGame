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

        conversation[1].conversation[1] = correct + " are correct.";
        if (correct >= pieces.Length){
            
        }
    }
}
