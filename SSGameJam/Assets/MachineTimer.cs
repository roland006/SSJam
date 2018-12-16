using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTimer : MonoBehaviour {

    public Animator anim;
    // Use this for initialization
    void Start () {
      
    }

    // Update is called once per frame
    void Update () {

       if (transform.parent.GetComponent<machine>().timer == 0)
       {
            anim.SetInteger("State",4);
            Debug.Log("1");
        }
       else if (transform.parent.GetComponent<machine>().timer == 1)
       {
            anim.SetInteger("State", 3);
            Debug.Log("2");
        }
       else if (transform.parent.GetComponent<machine>().timer == 2)
       {

            anim.SetInteger("State", 2);
            Debug.Log("3");
        }
       else if (transform.parent.GetComponent<machine>().timer == 3)
       {
            anim.SetInteger("State", 1);
            Debug.Log("4");
        }
       else if (transform.parent.GetComponent<machine>().timer == 4)
       {
            anim.SetInteger("State", 0);
            Debug.Log("5");
        }
    }
}
