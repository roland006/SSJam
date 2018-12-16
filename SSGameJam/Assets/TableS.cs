using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableS : MonoBehaviour {

    public GameObject playerCol;
    public Transform point;
    public bool stand;
    public int id;
    public bool i;
    public GameObject log;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerCol.GetComponent<take_an_object>().hold == false)
        {
            if (collision.gameObject.tag == "Object")
            {
                if (!stand)
                {
                    id = collision.gameObject.GetComponent<ObjectS>().objectName;
                    collision.gameObject.transform.position = point.position;
                    collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    stand = true;
                    if (i)
                        log.GetComponent<QuestLog>().UpdateLog(id);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            id = 0;
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            stand = false;
        }
    }


}
