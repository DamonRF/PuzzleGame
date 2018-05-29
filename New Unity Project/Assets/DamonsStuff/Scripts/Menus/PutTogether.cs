using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTogether : MonoBehaviour {

    public GameObject[] items;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Combine", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PutThemTogether()
    {
        PlayerPrefs.SetInt("Combine", 1);
    }

    public void ActivateItem(string itemName)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].GetComponent<Chest>().item == itemName)
            {
                items[i].SetActive(true);
                Debug.Log(items[i]);
                break;
            }
        }
    }
}
