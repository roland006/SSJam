using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABC : MonoBehaviour
{
    public static ABC instanceABC;
    public int pointABC;

    
    void Start()
    {

    }

    void Awake()
    {
        if (instanceABC == null)
            instanceABC = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}