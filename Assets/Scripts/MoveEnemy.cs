using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MoveEnemy : MonoBehaviour
{
    public float  MinimumSpeed, MaximumSpeed, HealthOfEnemy; // Сохраняет значение скоростей и здоровья врагов
    //public Text score; // Очки
    public float health; // Здоровье врага

    public int score_death = 2; // Кол-во очков получаемых при убийстве врага
    public float type; // Вид врага
    public float ExplodeVolume;
    public AudioSource explode_as;
    public AudioClip explode_ac;

    public GameObject score_counter;

    private GameObject player; // Игрок как объект
    private GameObject harder; // Игрок как объект
    private float speed; // Скорость врага
    private float posY; // Позиция врага
    private float max_speed, min_speed; // Скорость, которая имеет возможность изменяться
    private Transform trnsf; //Компоненты врага ниже
    private Collider2D collid;
    private Animator animator;
    //private Rigidbody2D rb;
    

    private void Start() {
        trnsf = GetComponent<Transform>();
        collid = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        harder = GameObject.Find("SpawnEnemies");
        score_counter = GameObject.Find("ScoreCount");

        max_speed = MaximumSpeed * harder.GetComponent<EnemySpawn>().max_mult;
        min_speed = MinimumSpeed * harder.GetComponent<EnemySpawn>().min_mult;
        health = HealthOfEnemy * harder.GetComponent<EnemySpawn>().h_mult;

        speed = UnityEngine.Random.Range(min_speed, max_speed); 
    }
    
    private void FixedUpdate() //Движение врага
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime);
    }



    private void OnTriggerEnter2D(Collider2D other) { // Срабатывает при столкновении
        if (other.gameObject.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            health -= player.GetComponent<PlayerCntrl>().damage;
            if(health <= 0)
            {
                Death();
            }
            StartCoroutine(_hit());

        }
        if(other.gameObject.name == "EnemyDestroyer")
        {
            Destroy(gameObject);
        }
    }

    private void _Score()// Добавляет очки
    {
        score_counter.GetComponent<ScoreCount>().Add_score(score_death);
        //score.text = Convert.ToString(Convert.ToInt32(score.text) + score_death);
    }

    private void Death()// Срабатывает при смерти врага
    {
        explode_as.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        explode_as.PlayOneShot(explode_ac, ExplodeVolume);

        _Score();
        speed /= 2f;
        Destroy(collid);
        if(type == 1)
        {
            animator.Play("Enemie_1_death");
        }
        else if(type == 2)
        {
            animator.Play("Enemie_2_death");
        }
        Invoke("_deathAnim", 0.66f);
    }

    public void _deathAnim()// Анимацифя смерти и уничтожение объекта
    {
        Destroy(gameObject);
    }

    public IEnumerator _hit()// Срабатывает при попадании по игроку (смена цвета)
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 0.787f, 0.291f, 1);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
