using System.Collections;

using UnityEngine;

using UnityEngine.UI;

public class Highscores : MonoBehaviour {

const string privateCode = "UCWM8L_nw0u_yBK3jiR-zQqHtHxmHpI0ezFsufWYyIyQ";
    const string publicCode = "5c1837d7b6398000e09b6ccd";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    DisplayHighscores highscoresDisplay;

    public Text enterName;

    public GameObject abc;

    public GameObject aabbcc;

    public bool qfa;



    private void Start()
    {
        aabbcc = GameObject.FindGameObjectWithTag("ABC");
        qfa = false;
    }


    void Awake()
    {
        highscoresDisplay = GetComponent<DisplayHighscores>();
    }

    public void AddNewHighscore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
            print("Upload Successful");
        else
        {
            print("Error uploading: " + www.error);
        }
    }

    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error)) { 
            FormatHighscores(www.text);
            highscoresDisplay.OnHighscoresDownloaded(highscoresList);
            }
        else
        {
            print("Error Downloading: " + www.error);
        }
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }

   public void Update()
    {
        if (Input.GetKey(KeyCode.Return) && qfa == false)
        {
            EnterName();
            qfa = true;
        }
    }

    public void EnterName()
    {
        if (enterName.text != string.Empty)
        {
            AddNewHighscore(enterName.text,aabbcc.GetComponent<ABC>().pointABC);

            enterName.text = string.Empty;
            Debug.Log("enterName.text");

            DownloadHighscores();
        }
    }
}



public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }

}
