using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {
    public GameObject interaction;
    public GameObject inventory;
    public GameObject chest;
    public GameObject itemInteract;
    public StringArray[] unableToConversation;
    public StringArray[] alreadySolvedConversation;
    private bool interacting = false;
    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("Interacting", 0);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(PlayerPrefs.GetInt("Interacting"));
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!interacting)
        {
            if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Interactable")
            {
                if (!collision.gameObject.GetComponent<Info>().isPuzzle)
                {
                    TransferInfo(collision.gameObject);
                }
                else
                {
                    if (collision.gameObject.GetComponent<Info>().puzzle.GetComponent<PuzzleManagement>().unlocked)
                    {
                        if (!collision.gameObject.GetComponent<Info>().puzzle.GetComponent<PuzzleManagement>().isSolved){
                            collision.gameObject.GetComponent<Info>().puzzle.GetComponent<PuzzleManagement>().OpenPuzzle();
                        } else
                        {
                            AlreadySolved();
                        }
                    }
                    else
                    {
                        TransferInfo(collision.gameObject);
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Chest")
            {
                ToggleMovement(true);
                inventory.SetActive(true);
                chest.SetActive(true);
                //Debug.Log("Bleeeeeeeegh");
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
        /*else if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "LightManager")
        {
            ToggleMovement(true);
            TransferLightPuzzleInfo(collision.gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "LightPiece")
        {
            collision.gameObject.GetComponent<LightPuzzle>().ChangePiece();
        } */
    }

    private void AlreadySolved()
    {
        interaction.SetActive(true);
        interaction.GetComponentInChildren<Typing>().Restart();
        interaction.GetComponentInChildren<Typing>().conversation = alreadySolvedConversation;
        ToggleMovement(true);
    }

    public void TransferLightPuzzleInfo(GameObject collision)
    {
        if (!interacting)
        {
            interaction.SetActive(true);
            interaction.GetComponentInChildren<Typing>().Restart();
            //collision.GetComponent<LightPuzzleManager>().CheckPieces();
            interaction.GetComponentInChildren<Typing>().conversation = collision.GetComponent<LightPuzzleManager>().conversation;
            ToggleMovement(true);
        }
        
    }

    public void InspectingItem(StringArray[] newConversation)
    {
        interaction.SetActive(true);
        interaction.GetComponentInChildren<Typing>().Restart();
        interaction.GetComponentInChildren<Typing>().conversation = newConversation;
        ToggleMovement(true);
    }
    

    private void TransferInfo(GameObject collision)
    {
        interaction.SetActive(true);
       
        interaction.GetComponentInChildren<Typing>().Restart();
        interaction.GetComponentInChildren<Typing>().conversation = collision.GetComponent<Info>().conversation;
        if (collision.GetComponent<Info>().needsItem && PlayerPrefs.GetInt("Interacting") == 1)
        {
            if (PlayerPrefs.GetString("Item") == collision.GetComponent<Info>().whatItem)
            {
                interaction.GetComponentInChildren<Typing>().conversationPlace = collision.GetComponent<Info>().whichConversation;
                itemInteract.GetComponent<ItemInteract>().UseItem();
                Debug.Log("Using Item");
            }
            else
            {
                interaction.GetComponentInChildren<Typing>().conversation = unableToConversation;
                itemInteract.GetComponent<ItemInteract>().CancelInteract();
            }
        }
        interaction.GetComponentInChildren<Typing>().item = collision.GetComponent<Info>().item;
        if (collision.GetComponent<Info>().item)
        {
            interaction.GetComponentInChildren<Typing>().itemObject = collision;
        }
        interaction.GetComponentInChildren<Typing>().onlyOnce = collision.GetComponent<Info>().onlyOnce;
        interaction.GetComponentInChildren<Typing>().activationSpot = collision;
        ToggleMovement(true);
    }

    public void ToggleMovement(bool talking)
    {
        if (talking)
        {
            GetComponent<SimpleMove>().enabled = false;
            interacting = true;
        } else
        {
            GetComponent<SimpleMove>().enabled = true;
            interacting = false;
        }
    }
}
