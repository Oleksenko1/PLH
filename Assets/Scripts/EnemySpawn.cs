using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] objs = new GameObject[2];
    public float chance2 = 30f;
    public float WaitEnemy = 0.5f;
    public float WaitHard = 2f;
    public float enemy_time;
    public float hard_time;

    
    //public Material Matr;

    private float timerEnemy = 0;
    private float timerHard = 0;
    private float chn;
    [NonSerialized] public float h_mult, min_mult, max_mult;
    
    

    private void Start() {
        h_mult = 1f;
        min_mult = 1f;
        max_mult = 1f;
        //StartCoroutine(CreateEnemy()); // Создаёт врагов
        //StartCoroutine(Harder()); // Увеличивает ХП и скорость врагов
        //Matr.color = new Color(1, 1, 1, 0);
    }

    public void FixedUpdate()
    {
        if (Time.time > timerHard)
        {
            WaitHard -= WaitHard / 100;
            min_mult *= 1.08f; // Минимальная скорость
            max_mult *= 1.08f; // Максимальная скорость
            h_mult *= 1.2f; // Здоровье
            
            timerHard = Time.time + WaitHard;
            WaitHard -= WaitHard / hard_time;

        }
        if (Time.time > timerEnemy)
        {
            WaitEnemy -= WaitEnemy / 100;
            timerEnemy = Time.time + WaitEnemy;
            chance();
        }
    }


    /*private IEnumerator CreateEnemy() // Спавн врагов
    {
        while(true)
        {
            yield return new WaitForSeconds(WaitEnemy);
            chance();
            if(WaitEnemy<0.2f)
            {
                continue;
            }
            WaitEnemy -= WaitEnemy/100; 
        }
    }*/

    private void Create(GameObject obj) // Создание врага
    {
        Instantiate(obj, new Vector3(rnd(-2.1f, 2.1f), 6.8f, 0f), Quaternion.Euler(0, 0, 180));
    }

    private float rnd(float min, float max) // Метод случайных чисел
    {
        return UnityEngine.Random.Range(min, max);
    }

    public void chance() // Случайность появления разных врагов
    {
        if(rnd(0, 101) < chance2)
        {
            Create(objs[1]);
        }
        else
        {
            Create(objs[0]);
        }
    }

    /*private IEnumerator Harder() // Увеличивает хп врагов 
    {
        while(true)
        {
            yield return new WaitForSeconds(WaitHard);
            for(int x = 0; x < objs.Length; x++)
            {
                min_mult *= 1.05f; // Минимальная скорость
                max_mult *= 1.05f; // Максимальная скорость
                h_mult *= 1.1f; // Здоровье
            }
        }
    }*/
}
