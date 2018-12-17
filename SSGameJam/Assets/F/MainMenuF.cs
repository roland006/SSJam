using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuF : MonoBehaviour {

    public AudioManager aM;
    public Animator anim;
    public GameObject audioM;
    public bool isP;

    private void Start()
    {
        audioM = GameObject.FindGameObjectWithTag("AudioM");
        aM = audioM.GetComponent<AudioManager>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DrownOut()
    {
        if (isP)
        {
            isP = false;
            anim.SetBool("animO", false);
            aM.Play("Theme");
            aM.AnMyt("Saw");
            aM.AnMyt("Swing");
            aM.AnMyt("Metal");
            aM.AnMyt("Success");
            aM.AnMyt("Fail");
            aM.AnMyt("Magic");
        }
        else
        {
            isP = true;
            anim.SetBool("animO", true);
            aM.Stop("Theme");
            aM.Myt("Saw");
            aM.Myt("Swing");
            aM.Myt("Metal");
            aM.Myt("Success");
            aM.Myt("Fail");
            aM.Myt("Magic");
        }

    }
}
