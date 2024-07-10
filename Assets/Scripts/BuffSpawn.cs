using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawn : MonoBehaviour
{
    public GameObject _dmg;
    public GameObject _fireRate;
    public float Chance = 10f;
    public float Wait = 1f;


    private float timer = 0;
    private float type;

    private void FixedUpdate()
    {
        if(Time.time > timer)
        {
            timer = Time.time + Wait;
            chance();
        }
    }


    private void Create(GameObject obj) // Создание улучшения
    {
        Instantiate(obj, new Vector3(rnd(-2.1f, 2.1f), 6.8f, 0f), Quaternion.Euler(0, 0, 0));
    }

    private float rnd(float min, float max) // Метод случайных чисел
    {
        return UnityEngine.Random.Range(min, max);
    }

    public void chance()
    { // Случайность - появится ли бафф
        if(rnd(0, 101) < Chance)
        {
            type = rnd(0, 101);// Определяет какой бафф появится
            if(type < 50)
            {
                Create(_dmg);
            }
            else
            {
                Create(_fireRate);
            }
        }
    }
}
