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
    public Vector3 spawnPosition;
    public GameObject spawnPoint;
    public GameObject[] objectPrefab;
    public GameObject audioM;
    public AudioManager aM;

    // Use this for initialization
    void Start () {
        audioM = GameObject.FindGameObjectWithTag("AudioM");
        aM = audioM.GetComponent<AudioManager>();
        spawnPosition = spawnPoint.transform.position;
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

        //if (table1.GetComponent<TableS>().id != 0)
            table[0] = table1.GetComponent<TableS>().id;
        //if (table2.GetComponent<TableS>().id != 0)
            table[1] = table2.GetComponent<TableS>().id;
        //if (table3.GetComponent<TableS>().id != 0)
            table[2] = table3.GetComponent<TableS>().id;

        if (table[0] != 0 && table[1] != 0 && table[2] != 0)
        {
            Magic();
            table1.GetComponent<TableS>().destroy = true;
            table2.GetComponent<TableS>().destroy = true;
            table3.GetComponent<TableS>().destroy = true;
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
                    table[0] = 0; table[1] = 0; table[2] = 0;
                    Instantiate(objectPrefab[0], spawnPosition, Quaternion.identity);
                    aM.GetComponent<AudioManager>().Play("Magic");
                    return;
                }

                    if (((IList<int>)codes).Contains(8)) //узоры
                    {
                        Debug.Log("Есть конечность+бревно+узоры");

                        Debug.Log("Получился солдатик");
                    table[0] = 0; table[1] = 0; table[2] = 0;
                    Instantiate(objectPrefab[1], spawnPosition, Quaternion.identity);
                    aM.GetComponent<AudioManager>().Play("Magic");
                    return;
                }
                    else
                    {
                        Debug.Log("Всё хуйня, давай по новой");
                        table[0] = 0; table[1] = 0; table[2] = 0;
                        Instantiate(objectPrefab[6], spawnPosition, Quaternion.identity);
                    aM.GetComponent<AudioManager>().Play("Magic");
                    return;
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
                    table[0] = 0; table[1] = 0; table[2] = 0;
                    Instantiate(objectPrefab[2], spawnPosition, Quaternion.identity);
                    aM.GetComponent<AudioManager>().Play("Magic");
                    return;
                }

                    if (((IList<int>)codes).Contains(9))//микросхема
                    {
                        Debug.Log("Есть бревно+колесо+микросхема");

                        Debug.Log("Получился вертолётик");
                    table[0] = 0; table[1] = 0; table[2] = 0;
                    Instantiate(objectPrefab[3], spawnPosition, Quaternion.identity);
                    aM.GetComponent<AudioManager>().Play("Magic");
                    return;
                }
                    else
                    {
                        Debug.Log("Всё хуйня, давай по новой");
                        table[0] = 0; table[1] = 0; table[2] = 0;
                        Instantiate(objectPrefab[6], spawnPosition, Quaternion.identity);
                    aM.GetComponent<AudioManager>().Play("Magic");
                    return;
                }
                }
            if (table[0] == table[1] && table[0] == table[2])
            {
                Debug.Log("Есть бревно");
            Debug.Log("Получились кубики");
            table[0] = 0; table[1] = 0; table[2] = 0;
            Instantiate(objectPrefab[4], spawnPosition, Quaternion.identity);
                aM.GetComponent<AudioManager>().Play("Magic");
                return;
            }
            else
            {
                Debug.Log("Всё хуйня, давай по новой");
                table[0] = 0; table[1] = 0; table[2] = 0;
                Instantiate(objectPrefab[6], spawnPosition, Quaternion.identity);
                aM.GetComponent<AudioManager>().Play("Magic");
                return;
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
                    table[0] = 0; table[1] = 0; table[2] = 0;
                    Instantiate(objectPrefab[5], spawnPosition, Quaternion.identity);
                    aM.GetComponent<AudioManager>().Play("Magic");
                    return;
                }
                    else
                    {
                        Debug.Log("Всё хуйня, давай по новой");
                        table[0] = 0; table[1] = 0; table[2] = 0;
                        Instantiate(objectPrefab[6], spawnPosition, Quaternion.identity);
                    aM.GetComponent<AudioManager>().Play("Magic");
                    return;
                }
                }
                else
                {
                    Debug.Log("Всё хуйня, давай по новой");
                    table[0] = 0; table[1] = 0; table[2] = 0;
                    Instantiate(objectPrefab[6], spawnPosition, Quaternion.identity);
                aM.GetComponent<AudioManager>().Play("Magic");
                return;
            }
            }
            else
            {
                Debug.Log("Всё хуйня, давай по новой");
                table[0] = 0; table[1] = 0; table[2] = 0;
                Instantiate(objectPrefab[6], spawnPosition, Quaternion.identity);
                aM.GetComponent<AudioManager>().Play("Magic");
            return;
            }

        

    }
}
