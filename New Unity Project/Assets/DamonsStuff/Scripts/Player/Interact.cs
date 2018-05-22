﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {
    public GameObject interaction;
    public GameObject inventory;
    public GameObject chest;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Interactable")
        {
            TransferInfo(collision.gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Chest")
        {
            ToggleMovement(true);
            inventory.SetActive(true);
            chest.SetActive(true);
            Debug.Log("Bleeeeeeeegh");
            inventory.GetComponentInChildren<NextMenu>().isChest = true;
            GameObject[] inventoryItems = inventory.GetComponent<InventoryManagement>().inventory;
            for (int i = 0; i < inventoryItems.Length; i++)
            {            
                inventoryItems[i].GetComponent<Chest>().atChest = true;
                //Debug.Log(i);
            }

            //inventory.GetComponentInChildren<Chest>().atChest = true;
            
        }
    }

    /*private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.GetComponent<Info>().interactable)
        {
            interaction.SetActive(true);
            interaction.GetComponentInChildren<Typing>().conversation = collision.gameObject.GetComponent<Info>().conversation;
        }
    }*/

    private void TransferInfo(GameObject collision)
    {
        interaction.SetActive(true);
       
        interaction.GetComponentInChildren<Typing>().Restart();
        interaction.GetComponentInChildren<Typing>().conversation = collision.GetComponent<Info>().conversation;
        interaction.GetComponentInChildren<Typing>().item = collision.GetComponent<Info>().item;
        if (collision.GetComponent<Info>().item)
        {
            interaction.GetComponentInChildren<Typing>().itemObject = collision;
        }
        interaction.GetComponentInChildren<Typing>().onlyOnce = collision.GetComponent<Info>().onlyOnce;
        interaction.GetComponentInChildren<Typing>().activationSpot = collision;
        ToggleMovement(true);
       /* } else
        {
            if (collision.GetComponent<Info>().needsItem && PlayerPrefs.GetString("Item") == collision.GetComponent<Info>().whatItem)
            {
                interaction.GetComponentInChildren<Typing>().Restart();
                interaction.GetComponentInChildren<Typing>().conversation = collision.GetComponent<Info>().conversation;
                interaction.GetComponentInChildren<Typing>().conversationPlace = collision.GetComponent<Info>().whichConversation;
                interaction.GetComponentInChildren<Typing>().item = collision.GetComponent<Info>().item;
                if (collision.GetComponent<Info>().item)
                {
                    interaction.GetComponentInChildren<Typing>().itemObject = collision;
                }
                interaction.GetComponentInChildren<Typing>().onlyOnce = collision.GetComponent<Info>().onlyOnce;
                interaction.GetComponentInChildren<Typing>().activationSpot = collision;
                ToggleMovement(true);
            } 
        }*/
    }

    public void ToggleMovement(bool talking)
    {
        if (talking)
        {
            GetComponent<SimpleMove>().enabled = false;
        } else
        {
            GetComponent<SimpleMove>().enabled = true;
        }
    }
}
