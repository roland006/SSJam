using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    public GameObject spawnPoint;
    public Vector3 spawnPosition;
    public GameObject[] objectPrefab;
    public float t;

    // Use this for initialization
    void Start () {
        spawnPosition = spawnPoint.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        t -= Time.deltaTime;
        if (t < 0)
        {
            Instantiate(objectPrefab[Random.Range(0, objectPrefab.Length)], spawnPosition, Quaternion.identity);
            t = 5;
        }
    }
}
