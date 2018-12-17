using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPriz : MonoBehaviour {

    public GameObject spawnPoint;
    public Vector3 spawnPosition;
    public GameObject[] objectPrefab;


    // Use this for initialization
    void Start()
    {
        spawnPosition = spawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnP ()
    {
        Instantiate(objectPrefab[Random.Range(0, objectPrefab.Length)], spawnPosition, Quaternion.identity);
    }
}
