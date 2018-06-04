using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Saving : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Player")
        {
            Save("state1");
            Debug.Log("Saved State 1");
        } else if (Input.GetKeyDown(KeyCode.Q) && collision.gameObject.tag == "Player")
        {
            Load("state1");
            Debug.Log("Loaded Save State 1");
        }
    }

    private void Save(string state)
    {
        BinaryFormatter bf = new BinaryFormatter();
        //ASSUMPTION: all objects using this script will have unique names
        FileStream file = File.Open(Application.persistentDataPath + "/" + state + gameObject.name + ".dat", FileMode.OpenOrCreate);
        SavingAttempt myData = new SavingAttempt();
        myData.maxPuzzles = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PuzzleTracker>().maxPuzzles;
        myData.puzzlesDone = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PuzzleTracker>().puzzlesDone;
        myData.inventory = player.GetComponent<Interact>().inventory.GetComponent<InventoryManagement>().inventory;
        bf.Serialize(file, myData);
        file.Close();
    }

    public void Load(string state)
    {
        if (File.Exists(Application.persistentDataPath +
            "/" + state + gameObject.name + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +
            "/" + state + gameObject.name + ".dat", FileMode.Open);
            SavingAttempt myData = (SavingAttempt)bf.Deserialize(file);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PuzzleTracker>().maxPuzzles = myData.maxPuzzles;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PuzzleTracker>().puzzlesDone = myData.puzzlesDone;
            player.GetComponent<Interact>().inventory.GetComponent<InventoryManagement>().inventory = myData.inventory;
            file.Close();
        }
    }
}

[System.Serializable]
public class SavingAttempt
{
    public int maxPuzzles;
    public int puzzlesDone;
    public GameObject[] inventory;
    
}
