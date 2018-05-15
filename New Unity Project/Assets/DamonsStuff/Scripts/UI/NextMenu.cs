using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMenu : MonoBehaviour {
    public GameObject nextMenu;
    public GameObject overallMenu;
    public GameObject chest;
    public bool opening = false;
    public bool isChest = false;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ButtoneClicky()
    {
        OpenNextMenu(opening, nextMenu);
        if (isChest)
        {
            chest.SetActive(false);
            player.GetComponent<Interact>().ToggleMovement(false);
            isChest = false;
            overallMenu.GetComponent<NextMenu>().isChest = false;
            overallMenu.GetComponentInChildren<Chest>().atChest = false;
        }
    }
    private void OpenNextMenu(bool opening, GameObject menu)
    {
        if (opening)
        {
            nextMenu.SetActive(true);
            overallMenu.SetActive(false);
        } else
        {
            nextMenu.SetActive(false);
            overallMenu.SetActive(true);
        }

    }
}
