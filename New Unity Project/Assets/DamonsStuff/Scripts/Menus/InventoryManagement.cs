using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagement : MonoBehaviour {

    public GameObject[] inventory;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Selected", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
