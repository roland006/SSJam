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

    SpriteRenderer[] Log_SpriteRenderer = new SpriteRenderer[3];   
    public GameObject[] LogSprite = new GameObject[3];

    // Use this for initialization
    void Start()
    {
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
                i = 3;
                Refresh(log[0], log[1], log[2]);
                TextBox.GetComponent<TextMesh>().text = ""+points;
                
            }
            else if( i == 2 && complete > 90)
            {
                Debug.Log("Сорян, ты сделал не то что требовалось, соси бибу, или что там у тебя..."); // хз чё делаем
                points = points + FailurePoint;
                i = 3;
                TextBox.GetComponent<TextMesh>().text = "" + points;
            }
            else if (complete <90)
            {
                Debug.Log("Ты нафига детям это отправляешь? ты что больной?"); // хз чё делаем
                i = 3; 
            }
            
        }
    }

    // Update is called once per frame
    void Update () {
        //Это для дебага, просто сделал вид что что то закинул в мешок (public complete вбиваю через Inspector )
        //if(Input.GetKeyDown(KeyCode.E))
        //{
        //    UpdateLog();
        //}
	}
}
