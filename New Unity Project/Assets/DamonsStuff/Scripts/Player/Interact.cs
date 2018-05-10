using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {
    public GameObject interaction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.GetComponent<Info>().interactable)
        {
            interaction.SetActive(true);
            interaction.GetComponentInChildren<Typing>().Restart();
            interaction.GetComponentInChildren<Typing>().conversation = collision.gameObject.GetComponent<Info>().conversation;
            ToggleMovement(true);
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
