using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float speed;

    private Transform trnsf;
    private float posY;
    private bool make = true;

    private void Start() {
        trnsf = GetComponent<Transform>();
    }

    private void FixedUpdate() { // Двигает фон
        // trnsf.Translate(new Vector3(0, -1, 0) * speed * Time.fixedDeltaTime);

        transform.Translate(new Vector3(0, -1, 0) * speed * Time.fixedDeltaTime);

        posY = trnsf.position.y;
        if(posY < 0.1f && make)
        {
            make = false;
            CreateAnother();
        }

        if(posY < -10.7)
        {
            Destroy(gameObject);
        }
    }

    private void CreateAnother() // Создаёт новое полотно фона
    {
        Instantiate(gameObject, new Vector3(0, 11.30f, 4f), Quaternion.Euler(0, 0, 0));
    }
}
