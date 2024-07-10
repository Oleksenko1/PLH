using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Animator anmtr;

    // public void Start()
    // {
        
    //     // mat_load = load.GetComponent<Material>();
    //     load = GameObject.Find("Loading");
    //     load.SetActive(false); 
    //     back_load = GameObject.Find("BackLoading");
    //     back_load.SetActive(false); 
    // }

    //private void FixedUpdate()
    //{
    //    if (active && Time.time > timer)
    //    {
    //        timer = Time.time + Wait;
    //        clr += 0.01f;
    //        if (clr >= 0.99f)
    //        {
    //            PlayLevel();
    //            active = false;
    //        }
    //        matr.color = new Color(1, 1, 1, clr);
    //    }
    //}

    public void Touched() // Срабатывает при нажатии на кнопку
    {
        //load.SetActive(true); 
        //load1.SetActive(true);
        //active = true;
        anmtr.Play("Load_all");
        Invoke("PlayLevel", 1.5f);
    }

    private void PlayLevel() // Начинает игру
    {
        SceneManager.LoadScene("SampleScene");
    }
}
