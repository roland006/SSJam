using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColS : MonoBehaviour {

    public GameObject machine;
    public Animator animatorSpace;
    public GameObject destObj;
    public int q = 4;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (q <= 0)
        {
            Destroy(destObj);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            machine.GetComponent<machine>().i = true;
            if (machine.GetComponent<machine>().work == true)
            {
                if (animatorSpace != null)
                {
                    animatorSpace.SetBool("space", true);
                    q -= 1;
                }
            }
            else
            {
                if (animatorSpace != null)
                    animatorSpace.SetBool("space", false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            machine.GetComponent<machine>().i = true;
            if (machine.GetComponent<machine>().work == true)
            {
                if (animatorSpace != null)
                    animatorSpace.SetBool("space", true);
            }
            else
            {
                if (animatorSpace != null)
                    animatorSpace.SetBool("space", false);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            machine.GetComponent<machine>().i = false;
            if (animatorSpace != null)
                animatorSpace.SetBool("space", false);
        }
    }
}
