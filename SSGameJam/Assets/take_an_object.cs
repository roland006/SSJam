using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class take_an_object : MonoBehaviour
{
    public Transform point;
    public GameObject col;
    public bool hold;
    private Rigidbody2D rb;
    public bool isCol;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetKeyDown("space") && col)
            {
              
            if (hold)
                hold = false;
            else
                hold = true;
            }

        if (hold)
        {
            col.gameObject.transform.position = point.position;
            rb.velocity = new Vector2(0f,0f);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!hold)
        {
            if (collision.gameObject.tag == "Object")
            {
                isCol = false;
                col = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hold)
        {
            if (collision.gameObject.tag == "Object")
            {
                isCol = true;
                col = collision.gameObject;
                rb = col.GetComponent<Rigidbody2D>();
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!hold)
        {
            if (collision.gameObject.tag == "Object")
            {
                isCol = true;
                col = collision.gameObject;
                rb = col.GetComponent<Rigidbody2D>();
            }
        }
    }
}