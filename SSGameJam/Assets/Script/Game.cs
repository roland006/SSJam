using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public GameObject obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            int score = Random.Range(0, 200);
            string username = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            for (int i=0; i< Random.Range(5,10); i++ )
            {
                username += alphabet[Random.Range(0, alphabet.Length)]; 
            }

            obj.GetComponent<Highscores>().AddNewHighscore(username, score);

            

        }
	}
}
