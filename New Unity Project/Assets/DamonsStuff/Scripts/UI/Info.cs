using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour {
    public bool interactable = false;
    public bool item = false;
    public bool onlyOnce = false;
    public bool needsItem = false;
    public bool isPuzzle = false;
    public string whatItem;
    public int whichConversation;
    public StringArray[] conversation;
    public GameObject puzzle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
