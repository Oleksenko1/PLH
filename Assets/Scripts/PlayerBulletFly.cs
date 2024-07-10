using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBulletFly : MonoBehaviour
{
    public float shotspeed = 1f;
    
   
    private void FixedUpdate() //Движение пули
    {
         transform.Translate(new Vector2(0, 1) * shotspeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) // Срабатывает при коллизизии с объектом
    {
        if(other.gameObject.name == "BulletDestroy")
        {
            Destroy(gameObject);
        }
    }

    
}
