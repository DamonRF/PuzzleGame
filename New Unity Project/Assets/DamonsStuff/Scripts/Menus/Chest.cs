using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour {
    public GameObject partner;
    public GameObject backButton;
    public GameObject interactMenu;
    public bool selected = false;
    public bool atChest = false;
	// Use this for initialization
	void Start () {
        //atChest = false;
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
    public void MoreOptions()
    {
        if (selected)
        {
            //backButton.SetActive(false);
            //interactMenu.SetActive(true);
            GetComponent<Image>().color = Color.yellow;
        }
    }
}
