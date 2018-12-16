using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableS : MonoBehaviour {

    public GameObject playerCol;
    public Transform point;
    public bool stand;
    public int id;
    public bool i;
    public bool destroy;
    public GameObject log;
    public GameObject objectT;
    public GameObject playerS;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (destroy)
        {
            Destroy(objectT);
            Debug.Log("destroy object");
            destroy = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerCol.GetComponent<take_an_object>().hold == false)
        {
            if (collision.gameObject.tag == "Object")
            {
                if (!stand)
                {
                    objectT = collision.gameObject;
                    id = collision.gameObject.GetComponent<ObjectS>().objectName;
                    collision.gameObject.transform.position = point.position;
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                    collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    stand = true;
                    if (i)
                    {
                        log.GetComponent<QuestLog>().UpdateLog(id);
                        destroy = true;
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            id = 0;
            objectT = null;
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            stand = false;
        }
    }


}
