using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspect : MonoBehaviour {

    public GameObject player;
    public StringArray[] conversation;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Inspecting()
    {
        player.GetComponent<Interact>().InspectingItem(conversation);
    }
}
