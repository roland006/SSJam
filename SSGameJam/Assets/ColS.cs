﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColS : MonoBehaviour {

    public GameObject machine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        machine.GetComponent<machine>().i = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        machine.GetComponent<machine>().i = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        machine.GetComponent<machine>().i = false;
    }
}
