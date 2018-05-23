using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagement : MonoBehaviour {
    bool isActive = false;
    public bool unlocked = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePuzzle();
        }
    }

    public void OpenPuzzle()
    {
        isActive = true;
        this.gameObject.SetActive(true);
    }

    public void ClosePuzzle()
    {
        isActive = false;
        this.gameObject.SetActive(false);
    }

    public void SolvePuzzle()
    {
        
    }
}
