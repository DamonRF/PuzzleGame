using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteract : MonoBehaviour {

    GameObject itemObject;
    public GameObject interacting;
    public GameObject manager;
    public GameObject selectedItem;
    public string itemName;
    string text;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Interacting", 0);
        text = interacting.GetComponentInChildren<Text>().text;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartInteracting()
    {
        PlayerPrefs.SetInt("Interacting", 1);
        manager.SetActive(false);
        interacting.SetActive(true);
        text = PlayerPrefs.GetString("Item");
        interacting.GetComponentInChildren<Text>().text = text;
    }
    public void UseItem()
    {
        /*for (int i = 0; i < manager.GetComponent<InventoryManagement>().inventory.Length; i++)
        {
            if (manager.GetComponent<InventoryManagement>().inventory[i].GetComponent<Chest>().item == itemName)
            {
                itemObject = manager.GetComponent<InventoryManagement>().inventory[i];
                Debug.Log(itemObject.name);
                break;
            }
        }*/
        //int index = -1;
        //    GameObject[] foo = manager.GetComponent<InventoryManagement>().inventory;
        //index = System.Array.IndexOf(foo, GameObject.Find(PlayerPrefs.GetString("Item")));
        

            //System.Array.IndexOf(manager.GetComponent<InventoryManagement>().inventory, manager.GetComponentInChildren<Chest>().item == PlayerPrefs.GetString("Item"));
        //Debug.Log(index);
        //itemObject = manager.GetComponent<InventoryManagement>().inventory[index];
        if (selectedItem.GetComponent<Chest>().isPuzzle)
        {
            selectedItem.GetComponent<Chest>().UnlockPuzzle();
            Debug.Log("Unlocking Puzzle");
        }
        selectedItem.SetActive(false);
        interacting.SetActive(false);
        PlayerPrefs.SetInt("Interacting", 0);
    }

    public void CancelInteract()
    {
        manager.SetActive(true);
        for (int i = 0; i < manager.GetComponent<InventoryManagement>().inventory.Length; i++)
        {
            if (manager.GetComponent<InventoryManagement>().inventory[i].GetComponent<Chest>().item == itemName)
            {
                itemObject = manager.GetComponent<InventoryManagement>().inventory[i];
                break;
            }
        }
        itemObject.GetComponent<Chest>().backButton.GetComponent<NextMenu>().ButtoneClicky();
        interacting.SetActive(false);
    }
}
