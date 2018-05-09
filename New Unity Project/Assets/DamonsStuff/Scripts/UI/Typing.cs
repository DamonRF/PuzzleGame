using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing : MonoBehaviour {
    public StringArray[] conversation;
    int conversationPlace = 0;
    int conversationIndex = 0;
    string text;
    float totalTime = 0;
    int charCount = 0;
    public float textSpeed = 0.1f;
    void Start()
    {
        //we are assuming we are attaching this script to a text object
        text = gameObject.GetComponent<Text>().text;
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
    }
    public void OnButtonClick()
    {
        conversationIndex++;
        charCount = 0;
    }
}
