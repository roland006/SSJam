﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine : MonoBehaviour
{

    public GameObject col;
    public int[] nameForObject;
    public Animator animator;
    public float t= 5;
    private bool active = false;
    public GameObject spawnPoint;
    public Vector3 spawnPosition;
    public GameObject[] objectPrefab;
    private int id;
    public bool work;
    public bool i;
    public GameObject playerCol;

    float constT;
    public int timer;
    public int Instate;
    SpriteRenderer cloud_SpriteRenderer;
    public GameObject cloud;

    public GameObject audioM;
    public AudioManager aM;

    public bool saw;
    public bool metal;
    public bool swing;

    // Use this for initialization
    void Start()
    {
        cloud_SpriteRenderer = cloud.GetComponent<SpriteRenderer>(); 
        constT = t;
        spawnPosition = spawnPoint.transform.position;
        audioM = GameObject.FindGameObjectWithTag("AudioM");
        aM = audioM.GetComponent<AudioManager>();

    }

    void Update()
    {

        if (Input.GetKeyDown("space") && col && !work)
        {
            if (col != null)
            {
                if (nameForObject[0] == col.GetComponent<ObjectS>().objectName)
                {
                    playerCol.GetComponent<take_an_object>().isCol = false;
                    playerCol.GetComponent<take_an_object>().col = null;
                    playerCol.GetComponent<take_an_object>().hold = false;
                    id = 0;
                    //
                    Instate = nameForObject[0];

                    active = true;
                    Destroy(col);
                    work = true;
                }
            }
            if (col != null)
            {
                if (nameForObject[1] == col.GetComponent<ObjectS>().objectName)
                {
                    playerCol.GetComponent<take_an_object>().isCol = false;
                    playerCol.GetComponent<take_an_object>().col = null;
                    playerCol.GetComponent<take_an_object>().hold = false;
                    id = 1;
                    //
                    Instate = nameForObject[1];
                    active = true;
                    Destroy(col);
                    work = true;
                }
            }
            if (col != null)
            {
                if (nameForObject[2] == col.GetComponent<ObjectS>().objectName)
                {
                    playerCol.GetComponent<take_an_object>().isCol = false;
                    playerCol.GetComponent<take_an_object>().col = null;
                    playerCol.GetComponent<take_an_object>().hold = false;
                    id = 2;
                    //
                    Instate = nameForObject[2];
                    active = true;
                    Destroy(col);
                    work = true;
                }
            }

        }
        if (active)
        {
            t -= Time.deltaTime;
            animator.SetBool("active", true);
            if (t < 4.8 && i && playerCol.GetComponent<take_an_object>().isCol == false)
            {
                if (Input.GetKeyDown("space"))
                {
                    animator.SetBool("active", false);
                    active = false;
                    Instantiate(objectPrefab[id], spawnPosition, Quaternion.identity);
                    t = 5;
                    Instate = 0;
                    work = false;
                    Debug.Log("stop1");
                }
            }
            if (id == 3)
            {
                if (metal)
                    aM.GetComponent<AudioManager>().Play("Metal");
                if (swing)
                    aM.GetComponent<AudioManager>().Play("Swing");
                if (saw)
                    aM.GetComponent<AudioManager>().Play("Saw");
                animator.SetBool("active", false);
                active = false;
                Instantiate(objectPrefab[id], spawnPosition, Quaternion.identity);
                t = 5;
                Instate = 0;
                work = false;
                Instate = 0;
                Debug.Log("stop2");
            }
            if (t < 0)
            {
                
                if (id == 2)
                {
                    if (metal)
                        aM.GetComponent<AudioManager>().Play("Metal");
                    if (swing)
                        aM.GetComponent<AudioManager>().Play("Swing");
                    if (saw)
                        aM.GetComponent<AudioManager>().Play("Saw");
                    Instate = nameForObject[id];
                    id = 3;
                    Debug.Log("id = 3");
                    t = 5;
                }

                if (id == 1)
                {
                    if (metal)
                        aM.GetComponent<AudioManager>().Play("Metal");
                    if (swing)
                        aM.GetComponent<AudioManager>().Play("Swing");
                    if (saw)
                        aM.GetComponent<AudioManager>().Play("Saw");
                    id = 2;
                    Instate = nameForObject[id];
                    Debug.Log("id = 2");
                    t = 5;
                }
                if (id == 0)
                {
                    id = 1;
                    Instate = nameForObject[id];
                    Debug.Log("id = 1");
                    t = 5;
                    if (metal)
                    {
                        aM.GetComponent<AudioManager>().Play("Metal");
                    }
                    if (swing)
                    {
                        aM.GetComponent<AudioManager>().Play("Swing");
                    }
                    if (saw)
                    {
                        aM.GetComponent<AudioManager>().Play("Saw");
                    }
                }
            }
        }
        

            ////////
        if (t <= constT * 0.2f && work == true)
        {
            timer = 0;
            cloud_SpriteRenderer.sortingOrder = 5;
        }
        else if (t > constT * 0.2f && t <= constT * 0.4f && work == true)
        {
            timer = 1;
            cloud_SpriteRenderer.sortingOrder = 5;
        }
        else if (t > constT * 0.4f && t <= constT * 0.6f && work == true)
        {
            timer = 2;
            cloud_SpriteRenderer.sortingOrder = 5;
        }
        else if (t > constT * 0.6f && t <= constT * 0.8f && work == true)
        {
            timer = 3;
            cloud_SpriteRenderer.sortingOrder = 5;

        }
        else if (t > constT * 0.8f && t <= constT && work == true)
        {
            timer = 4;
            cloud_SpriteRenderer.sortingOrder = 5;
        }
        else
        {
            //cloud.transform.position = new Vector3(xpos,ypos, -1);
            cloud_SpriteRenderer.sortingOrder = -10;
           
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            col = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Object")
        {
            col = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            col = collision.gameObject;
        }
    }
}