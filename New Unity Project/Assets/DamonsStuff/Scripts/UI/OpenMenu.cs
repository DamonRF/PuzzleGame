using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour {
    public GameObject menu;
    bool menuOpen = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeMenu(menuOpen);
        }
	}

    public void ChangeMenu(bool onOrOff)
    {
        //true means it is on, false means it is off 
        if (onOrOff)
        {
            menu.SetActive(false);
            menuOpen = false;
        } else
        {
            menu.SetActive(true);
            menuOpen = true;
        }
        Debug.Log(menuOpen);
    }
}
