using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour {

    public int SuccessPoint; //количество очков за правильный подарок
    public int FailurePoint; //количество очков за неправильный подарок
    int points;
    int [] log = new int [3];
    public GameObject TextBox;

    // Use this for initialization
    void Start()
    {
        points = 0;
        //заряжаем в квест лог рандомные переменные (от 0 до 5) где переменная - код требуемой игрушки
        log[0] = Random.Range(100, 105);
        log[1] = Random.Range(100, 105);
        log[2] = Random.Range(100, 105);
        //GameObject TextBox = gameObject.transform.Find("TextBlock").gameObject;
        TextBox.GetComponent<TextMesh>().text = " " + log[0] + "; " + log[1] + "; " + log[2];
        Debug.Log(log[0] + " " + log[1] + " " + log[2]);
    }
    public void UpdateLog(int complete)
    {
        //выполняем этот метод после того как подарок (complete) оказался в мешке. Если подарок совпадает с квестлогом log[], то мы начисляем очки, если нет, то ничего не происходит.
        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            if (log[i] == complete)
            {
                log[i] = Random.Range(100, 105);
                //тут надо проиграть анимацию замены иконки со старой на новую

                Debug.Log("Молодец, ты сделал" + complete + "Получи новую задачу:" + log[i]); //начисялем очки
                points = points + SuccessPoint;
                i = 3;
                TextBox = gameObject.transform.Find("TextBlock").gameObject; //ищем дочерний объект TextBlock, у которого есть TextMesh, в который выводятся квесты
                TextBox.GetComponent<TextMesh>().text = " " + log[0] + "; " + log[1] + "; " + log[2];
                return;
            }
            count++;
        }
        if (count == 3)
        {
            Debug.Log("Сорян, ты сделал не то что требовалось, соси бибу, или что там у тебя..."); // хз чё делаем
            points = points + FailurePoint;
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
