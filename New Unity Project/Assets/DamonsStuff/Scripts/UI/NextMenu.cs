using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMenu : MonoBehaviour {
    public GameObject nextMenu;
    public GameObject overallMenu;
    public bool opening;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ButtoneClicky()
    {
        OpenNextMenu(opening, nextMenu);
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
