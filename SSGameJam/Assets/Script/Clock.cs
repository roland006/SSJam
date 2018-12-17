using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {


    public Animator anim;
    public float timer;
    float ConstT;
    
    // Use this for initialization
    void Start()
    {
        ConstT = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            anim.SetInteger("Hour", 5);
        }
        if (timer > ConstT * 0.01f && timer <= ConstT * 0.2f)
        {
            anim.SetInteger("Hour", 4);
        }
        else if (timer > ConstT * 0.2f && timer <= ConstT * 0.4f)
        {
            anim.SetInteger("Hour", 3);
        }
        else if (timer > ConstT * 0.4f && timer <= ConstT * 0.6f)
        {

            anim.SetInteger("Hour", 2);
        }
        else if (timer > ConstT * 0.6f && timer <= ConstT * 0.8f)
        {
            anim.SetInteger("Hour", 1);
        }
        //else if (timer > ConstT * 0.8f && timer <= ConstT)
        //{
        //    anim.SetInteger("Hour", 1);
        //}
    }
}

