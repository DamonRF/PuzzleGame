using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTracker : MonoBehaviour {

    public int maxPuzzles = 2;
    public int puzzlesDone = 0;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdatePuzzlesDone()
    {
        puzzlesDone++;
        Debug.Log("Puzzles Done: " + puzzlesDone);
    }
}
