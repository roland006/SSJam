using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPriz : MonoBehaviour {

    public GameObject spawnPoint;
    public Vector3 spawnPosition;
    public GameObject[] objectPrefab;
    public Animator boxAnim;
    public float t= -1;
    public bool i;

    // Use this for initialization
    void Start()
    {
        spawnPosition = spawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        t -= Time.deltaTime;
        if (t < 0 && i)
        {
            i = false;
            boxAnim.SetBool("anim", false);
            Instantiate(objectPrefab[Random.Range(0, objectPrefab.Length)], spawnPosition, Quaternion.identity);
        }
    }

    public void SpawnP ()
    {
        t = 0.5f;
        boxAnim.SetBool("anim", true);
        i = true;
    }
}
