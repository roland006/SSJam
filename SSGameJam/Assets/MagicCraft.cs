using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MagicCraft : MonoBehaviour {


    public int[] table = new int[3];

    public GameObject table1;
    public GameObject table2;
    public GameObject table3;

    // Use this for initialization
    void Start () {

        //Создаю массив с айтемами, заполняю его уникальными номерами для дальнейшей идентификации предметов в крафте
        int ResTypes = 3; //Кол-во возможных ресурсов (Дерево, Ткань, Железо)
        int TierTypes = 4; //Количество возможных тиров (полено, брусок, конечность, мусор)
        
        int[,] items = new int[TierTypes, ResTypes];

        int UID = 1;
        for (int i = 0; i< TierTypes; i++)
        {
            for(int j=0; j< ResTypes; j++)
            {
                items[i, j] = UID;
                UID++;                
            }
        }

        Debug.Log(table[0]);
        Debug.Log(table[1]);
        Debug.Log(table[2]);
        
    }

    // Update is called once per frame
    void Update () {

        if (table1.GetComponent<TableS>().id != 0)
            table[0] = table1.GetComponent<TableS>().id;
        if (table2.GetComponent<TableS>().id != 0)
            table[1] = table1.GetComponent<TableS>().id;
        if (table3.GetComponent<TableS>().id != 0)
            table[2] = table1.GetComponent<TableS>().id;

        if (table[0] != 0 && table[1] != 0 && table[2] != 0)
        {
            Magic();
        }
    }

    void Magic ()
    {

        
            // Брусок конечность платье

            int[] codes = { table[0], table[1], table[2] };

            if (((IList<int>)codes).Contains(4))//бревно
            {
                Debug.Log("Есть бревно");
                //конечность
                if (((IList<int>)codes).Contains(7)) //колесо
                {
                    Debug.Log("Есть конечность+бревно");

                    if (((IList<int>)codes).Contains(5))//платье
                    {
                        Debug.Log("Есть конечность+бревно+платье");

                        Debug.Log("Получилась кукла");
                    }

                    if (((IList<int>)codes).Contains(8)) //узоры
                    {
                        Debug.Log("Есть конечность+бревно+узоры");

                        Debug.Log("Получился солдатик");
                    }
                    else
                    {
                        Debug.Log("Всё хуйня, давай по новой");
                    }
                }
                //колесо
                if (((IList<int>)codes).Contains(6))//колесо
                {
                    Debug.Log("Есть бревно+колесо");
                    if (((IList<int>)codes).Contains(8))//узоры
                    {
                        Debug.Log("Есть бревно+колесо+узоры");

                        Debug.Log("Получилась машинка");
                    }

                    if (((IList<int>)codes).Contains(9))//микросхема
                    {
                        Debug.Log("Есть бревно+колесо+микросхема");

                        Debug.Log("Получился вертолётик");
                    }
                    else
                    {
                        Debug.Log("Всё хуйня, давай по новой");
                    }
                }
                if (table[0] == table[1] && table[0] == table[2])
                {
                    Debug.Log("Получились кубики");

                }
                else
                {
                    Debug.Log("Всё хуйня, давай по новой");
                }
            }
            else if (((IList<int>)codes).Contains(6))//колесо
            {
                Debug.Log("Нет бревна, но есть колесо");

                if (((IList<int>)codes).Contains(9))//микросхема
                {
                    Debug.Log("Есть колесо+микросхема");

                    if (((IList<int>)codes).Contains(8))//узоры
                    {
                        Debug.Log("Есть колесо+микросхема");

                        Debug.Log("Получился робот");
                    }
                    else
                    {
                        Debug.Log("Всё хуйня, давай по новой");
                    }
                }
                else
                {
                    Debug.Log("Всё хуйня, давай по новой");
                }
            }
            else
            {
                Debug.Log("Всё хуйня, давай по новой");
            }

        

    }
}
