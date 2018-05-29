using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMenu : MonoBehaviour {
    public GameObject nextMenu;
    public GameObject overallMenu;
    public GameObject chest;
    public GameObject selectedThing;
    public GameObject manager;
    public bool opening = false;
    public bool isChest = false;
    public bool selected = false;
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
            //overallMenu.GetComponent<NextMenu>().isChest = false;
            GameObject[] inventoryItems = overallMenu.GetComponent<InventoryManagement>().inventory;
            for (int i = 0; i < inventoryItems.Length; i++)
            {
                inventoryItems[i].GetComponent<Chest>().atChest = false;
            }
            //overallMenu.GetComponentInChildren<Chest>().atChest = false;
        }
        if (selected)
        {
            //Debug.Log("1");
            for (int i = 0; i < manager.GetComponent<InventoryManagement>().inventory.Length; i++)
            {
               // Debug.Log("2" + manager.GetComponent<InventoryManagement>().inventory[i].GetComponent<Chest>().item);
                
                if (manager.GetComponent<InventoryManagement>().inventory[i].GetComponent<Chest>().item == PlayerPrefs.GetString("Item"))
                {
                    //Debug.Log("foo");
                    selectedThing = manager.GetComponent<InventoryManagement>().inventory[i];
                    break;
                }
            }
            selectedThing.GetComponent<Chest>().Reset();
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
