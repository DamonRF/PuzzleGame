﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrayOfArray : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[Serializable]
public class StringArray
{
    public string[] conversation;
}

[Serializable]
public class BoolArray
{
    public bool[] trueOrFalse;
}

[Serializable]
public class InventoryArray
{
    public GameObject[] inventory;
}