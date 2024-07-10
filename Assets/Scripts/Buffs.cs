using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public string buff;
    public float speed;
    public GameObject[] anims = new GameObject[2];
    public GameObject[] VFX_pickUp = new GameObject[2];

    public float dmg_up = 2f;
    public float fireRate_up = 0.01f;

    private float posX;
    private float posY;

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, -1, 0) * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (buff == "Damage")
            {
                other.gameObject.GetComponent<PlayerCntrl>().damage += dmg_up;
            }
            else if (buff == "FireRate")
            {
                if (other.gameObject.GetComponent<PlayerCntrl>()._fireRate <= 0.03f) // Если скорострельность достигла границы
                {
                    fireRate_up = 0f;
                }
                other.gameObject.GetComponent<PlayerCntrl>()._fireRate -= fireRate_up;
            }

            Anim();
        }

        else if (other.gameObject.name == "EnemyDestroyer")
        {
            Destroy(gameObject);
        }
    }

    private void Anim()
    {
        posY = transform.position.y;
        posX = transform.position.x;

        if (buff == "Damage")
        {
            Instantiate(anims[0], new Vector3(posX, posY, 1f), Quaternion.Euler(0, 0, 0));
            Instantiate(VFX_pickUp[0], new Vector3(posX, posY, 1f), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            Instantiate(anims[1], new Vector3(posX, posY, 1f), Quaternion.Euler(0, 0, 0));
            Instantiate(VFX_pickUp[1], new Vector3(posX, posY, 1f), Quaternion.Euler(0, 0, 0));
        }

        Destroy(gameObject);
    }
}
