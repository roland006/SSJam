using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColS : MonoBehaviour {

    public GameObject machine;
    public Animator animatorSpace;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            machine.GetComponent<machine>().i = true;
            if (machine.GetComponent<machine>().work == true)
                animatorSpace.SetBool("space", true);
            else
                animatorSpace.SetBool("space", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            machine.GetComponent<machine>().i = true;
            if (machine.GetComponent<machine>().work == true)
                animatorSpace.SetBool("space", true);
            else
                animatorSpace.SetBool("space", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            machine.GetComponent<machine>().i = false;
            animatorSpace.SetBool("space", false);
        }
    }
}
