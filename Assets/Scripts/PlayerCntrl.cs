using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerCntrl : MonoBehaviour
{
    public float speed = 1f;
    public float _fireRate = 0.5f; 
    public float damage = 4f;
    public float ShotVolume;
    private bool alive = true;
    private bool isMoving = false; 
    private bool barrel1 = true; // Из какой пушки стрелять
    public AudioSource shoot_as;
    public AudioClip shoot_ac;
    public AudioSource buff_as;
    public AudioClip buff_ac;


    public GameObject spawnStop;
    public GameObject _dead; //Включает объект смерти
    public GameObject shot; // Объект выстрела
    public GameObject[] shotSpawn = new GameObject[2];


    private Vector3 targetPosition;
    private Animator animator;
    

    void Start(){
        animator = GetComponent<Animator>();
        StartCoroutine(_Shoot());
    }

    

    private void FixedUpdate() // Постоянное обновление и работа
    {
        if(alive == false)
        {
            DeathAnim();
            return;
        }
        if(Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }

        if(isMoving)
        {
            Move();
        }
    }
    
    private void SetTargetPosition() // Получение координат нажатия
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }

    private void Move() // Движение самого объекта
    {
        if (targetPosition.y > 3.5 && targetPosition.x > 1.3)
        {
            return;
        }
        else
        {
            targetPosition = new Vector2(Math.Clamp(targetPosition.x, -2.5f, 2.5f), Mathf.Clamp(targetPosition.y, -4.9f, 4.3f));
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // При столкновении с врагом
    {
        if (other.gameObject.tag == "Enemy")
        {
            kill();
        }
        else if (other.gameObject.tag == "Buff")
        {
            buff_as.PlayOneShot(buff_ac);
        }
    }

    private void DeathAnim()// Срабатывает при смерти объекта
    {
        transform.Translate(new Vector2(0, -2) * Time.fixedDeltaTime);
        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator _Shoot()// Выстрелы игрока
    {
        while(alive)
        {
            barrel1 = !barrel1;
            yield return new WaitForSeconds(_fireRate);

            shoot_as.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
            shoot_as.PlayOneShot(shoot_ac, ShotVolume);

            if (barrel1 && alive)
            {
                Instantiate(shot, shotSpawn[0].transform.position, shotSpawn[0].transform.rotation);
            }
            else if(!barrel1 && alive)
            {
                Instantiate(shot, shotSpawn[1].transform.position, shotSpawn[1].transform.rotation);
            }
            
        }
    }

    private void kill()// Команды после смерти врага
    {
        alive = false;
        animator.Play("Player_Death");
        _dead.SetActive(true);
    }

    

    
}
