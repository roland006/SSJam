using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour {

    public int SuccessPoint; //количество очков за правильный подарок
    public int FailurePoint; //количество очков за неправильный подарок
    int points;
    int [] log = new int [3];
    
    public GameObject TextBox;
    public Animator[] anim = new Animator[3];
    public Animator suckAss;

    SpriteRenderer[] Log_SpriteRenderer = new SpriteRenderer[3];   
    public GameObject[] LogSprite = new GameObject[3];

    public float t = 10;
    public GameObject audioM;
    public AudioManager aM;

    public GameObject abc;
    public GameObject aabbcc;

    // Use this for initialization
    void Start()
    {
        aabbcc = GameObject.FindGameObjectWithTag("ABC");
        audioM = GameObject.FindGameObjectWithTag("AudioM");
        aM = audioM.GetComponent<AudioManager>();
        for (int i = 0; i < 3; i++)
        {
            Log_SpriteRenderer[i] = LogSprite[i].GetComponent<SpriteRenderer>();
        }
        points = 0;
        //заряжаем в квест лог рандомные переменные (от 0 до 5) где переменная - код требуемой игрушки
        log[0] = Random.Range(100, 105);
        log[1] = Random.Range(100, 105);
        log[2] = Random.Range(100, 105);
        Refresh(log[0],log[1],log[2]);
    }

    public void Refresh(int x, int y, int z)
    {
        for (int i = 0; i < 3; i++)
        {
            anim[i].SetInteger("Toy", log[i] - 100);
            
        }
    }

    public void UpdateLog(int complete)
    {
        //выполняем этот метод после того как подарок (complete) оказался в мешке. Если подарок совпадает с квестлогом log[], то мы начисляем очки, если нет, то ничего не происходит.
      
            for (int i = 0; i < 3; i++)
        {
            if (log[i] == complete && complete > 90)
            {
                log[i] = Random.Range(100, 105);
                //тут надо проиграть анимацию замены иконки со старой на новую

                Debug.Log("Молодец, ты сделал" + complete + "Получи новую задачу:" + log[i]); //начисялем очки
                
                points = points + SuccessPoint;
                aabbcc.GetComponent<ABC>().pointABC = points;
                i = 3;
                Refresh(log[0], log[1], log[2]);
                TextBox.GetComponent<TextMesh>().text = ""+points;
                t = -1;
                suckAss.SetInteger("Finger", 1);
                aM.GetComponent<AudioManager>().Play("Success");
                t = 2;
            }
            else if( i == 2 && complete > 90)
            {
                
                Debug.Log("Сорян, ты сделал не то что требовалось, соси бибу, или что там у тебя..."); // хз чё делаем
                points = points + FailurePoint;
                aabbcc.GetComponent<ABC>().pointABC = points;
                i = 3;
                TextBox.GetComponent<TextMesh>().text = "" + points;
                t = -1;
                suckAss.SetInteger("Finger", 2);
                aM.GetComponent<AudioManager>().Play("Fail");
                t = 2;
            }
            else if (complete <90)
            {
                points = points - 1;
                aabbcc.GetComponent<ABC>().pointABC = points;
                Debug.Log("Ты нафига детям это отправляешь? ты что больной?"); // хз чё делаем
                i = 3;
                TextBox.GetComponent<TextMesh>().text = "" + points;
                t = -1;
                suckAss.SetInteger("Finger", 2);
                aM.GetComponent<AudioManager>().Play("Fail");
                t = 2;
            }
            
        }
    }
    

    void Update () {
        
        t -= Time.deltaTime;
        if (t < 0)
        {
            suckAss.SetInteger("Finger", 0);

        }
    }
}
