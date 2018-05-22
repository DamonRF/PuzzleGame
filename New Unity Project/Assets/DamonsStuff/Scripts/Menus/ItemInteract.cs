using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteract : MonoBehaviour {

    public GameObject interacting;
    public GameObject manager;
    public string item;
   
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Interacting", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartInteracting()
    {
        PlayerPrefs.SetInt("Interacting", 1);
        manager.SetActive(false);
        interacting.SetActive(true);
    }
}
