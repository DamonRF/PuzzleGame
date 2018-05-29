using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing : MonoBehaviour {
    public StringArray[] conversation;
    public int conversationPlace = 0;
    int conversationIndex = 0;
    string text;
    float totalTime = 0;
    int charCount = 0;
    public GameObject parent;
    public GameObject activationSpot;
    public GameObject player;
    public GameObject yesOrNo;
    public GameObject itemObject;
    public bool item = false;
    public bool choice = false;
    public bool loadScene = false;
    public bool instantStart = false;
    public string sceneName;
    bool activateME = false;
    private bool isTalking = false;
    public bool semiCutscene = false;
    public bool onlyOnce = false;
    public bool branching = false;
    public float textSpeed = 0.1f;
    //public bool doTheThing = false;
    void Start()
    {
        //we are assuming we are attaching this script to a text object
        text = gameObject.GetComponent<Text>().text;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        text = conversation[conversationPlace].conversation[conversationIndex];
        totalTime += Time.deltaTime;
        if (totalTime >= textSpeed && charCount < text.Length)
        {
            //if our time is greater than or equal to the time interval
            //do the thing
            charCount += 1;
            totalTime = 0;
        }
        string words = text.Substring(0, charCount);
        /*if (totalTime > textSpeed/2f) {
			words = words + "|";
			if (totalTime > textSpeed) {
				totalTime = 0;
			}
		}*/
        gameObject.GetComponent<Text>().text = words;
        if (Input.GetKeyDown(KeyCode.E) && activateME)
        {
            conversationIndex++;
            charCount = 0;
            if (conversationIndex >= conversation[conversationPlace].conversation.Length)
            {
                if (item)
                {
                    itemObject.GetComponent<Pickup>().PickupItem();
                }
                /*if (doTheThing)
                {

                }*/
                if (onlyOnce)
                {
                    activationSpot.SetActive(false);
                }
                if (choice)
                {
                    yesOrNo.SetActive(true);
                }
                else
                {
                    EndConversation();
                }
                
                
            }
        }
        activateME = true;
    }
    public void Restart()
    {
        conversationPlace = 0;
        conversationIndex = 0;
        charCount = 0;
        totalTime = 0;
        activateME = false;
        item = false;
        choice = false;
    }
    public void EndConversation()
    {
        Debug.Log("Ended Conversation");
        player.GetComponent<Interact>().ToggleMovement(false);
        Restart();
        parent.SetActive(false);
    }
}
