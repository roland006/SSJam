using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanel : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(speed , collision.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
