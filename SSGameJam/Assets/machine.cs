using System.Collections;
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
    private bool work;
    public bool i;

    // Use this for initialization
    void Start()
    {
        spawnPosition = spawnPoint.transform.position;
    }

    void Update()
    {
        
        if (Input.GetKeyDown("space") && col && !work)
        {
            if (nameForObject[0] == col.GetComponent<ObjectS>().objectName)
            {
                id = 0;
                active = true;
                Destroy(col);
                work = true;
                Debug.Log("nameForObject[0]");
            }
            if (nameForObject[1] == col.GetComponent<ObjectS>().objectName)
            {
                id = 1;
                active = true;
                Destroy(col);
                work = true;
            }
            if (nameForObject[2] == col.GetComponent<ObjectS>().objectName)
            {
                id = 2;
                active = true;
                Destroy(col);
                work = true;
                Debug.Log("go");
            }

        }
        if (active)
        {
            t -= Time.deltaTime;
            animator.SetBool("active", true);
            if (t < 4.8)
            {
                if (Input.GetKeyDown("space"))
                {
                    animator.SetBool("active", false);
                    active = false;
                    Instantiate(objectPrefab[id], spawnPosition, Quaternion.identity);
                    t = 5;
                    work = false;
                    Debug.Log("stop1");
                }
            }
            if (id == 3)
            {
                animator.SetBool("active", false);
                active = false;
                Instantiate(objectPrefab[id], spawnPosition, Quaternion.identity);
                t = 5;
                work = false;
                Debug.Log("stop2");
            }
            if (t < 0)
            {
                
                if (id == 2)
                {
                    id = 3;
                    Debug.Log("id = 3");
                    t = 5;
                }

                if (id == 1)
                {
                    id = 2;
                    Debug.Log("id = 2");
                    t = 5;
                }
                if (id == 0)
                {
                    id = 1;
                    Debug.Log("id = 1");
                    t = 5;
                }
            }
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