using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {
    public GameObject partner;
    public bool atChest = false;
	// Use this for initialization
	void Start () {
        atChest = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TransferOver()
    {
        if (atChest)
        {
            partner.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
