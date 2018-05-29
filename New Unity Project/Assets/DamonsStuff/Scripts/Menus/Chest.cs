using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour {
    public GameObject partner;
    public GameObject backButton;
    public GameObject interactMenu;
    public GameObject manager;
    public GameObject puzzle;
    public bool isPuzzle = false;
    public bool selected = false;
    public bool atChest = false;
    public string item;
    public StringArray[] itemDescription;
	// Use this for initialization
	void Start () {
        //atChest = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(PlayerPrefs.GetString("Item"));
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
        if (PlayerPrefs.GetInt("Selected") == 0 && !atChest)
        {
            PlayerPrefs.SetInt("Selected", 1);
            PlayerPrefs.SetString("Item", item);
            backButton.SetActive(false);
            interactMenu.SetActive(true);
            interactMenu.GetComponentInChildren<ItemInteract>().selectedItem = this.gameObject;
            interactMenu.GetComponentInChildren<Inspect>().conversation = itemDescription;
            GetComponent<Image>().color = Color.yellow;
            selected = true;
        } else if (PlayerPrefs.GetInt("Combine") == 1)
        {
            if (PlayerPrefs.GetString("Item") == "Paper" && item == "Scissors" || PlayerPrefs.GetString("Item") == "Scissors" && item == "Paper")
            {
                interactMenu.GetComponentInChildren<PutTogether>().ActivateItem("Paper Cut-Out");
                interactMenu.GetComponentInChildren<NextMenu>().ButtoneClicky();
                for (int i = 0; i < manager.GetComponent<InventoryManagement>().inventory.Length; i++)
                {
                    if (manager.GetComponent<InventoryManagement>().inventory[i].GetComponent<Chest>().item == PlayerPrefs.GetString("Item"))
                    {
                        manager.GetComponent<InventoryManagement>().inventory[i].SetActive(false);
                        break;
                    }
                }
                this.gameObject.SetActive(false);
            }
        }
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Selected", 0);
        GetComponent<Image>().color = Color.white;
        selected = false;
        backButton.SetActive(true);
    }

    public void UnlockPuzzle()
    {
        puzzle.GetComponent<PuzzleManagement>().unlocked = true;
        Debug.Log("Should be unlocked");
    }
}
