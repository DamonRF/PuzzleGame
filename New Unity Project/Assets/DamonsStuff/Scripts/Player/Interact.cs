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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetButtonDown("e") && collision.gameObject.GetComponent<Info>().interactable)
        {
            interaction.GetComponentInChildren<Typing>().conversation = collision.gameObject.GetComponent<Info>().conversation;
        }
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
