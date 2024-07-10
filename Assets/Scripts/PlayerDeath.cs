using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class PlayerDeath : MonoBehaviour
{
    public GameObject Panel;
    public GameObject[] SpawnStop = new GameObject[2];
    public Text[] score = new Text[2];
    public GameObject PauseButton;
    public GameObject Final_panel;
    public GameObject Final_panel_score;


    [NonSerialized] public int final_score_1;
    public AudioMixerSnapshot Dead;

    void Start(){
        StartCoroutine(Restart());

        final_score_1 = Convert.ToInt32(score[0].GetComponent<Text>().text);
        Destroy(SpawnStop[0]); // Остановка появления врагов
        Destroy(SpawnStop[1]); // Остановка появления бафов
        Destroy(PauseButton); // Удаление кнопки паузы

        Invoke("Final_panel_show", 1f);

        score[0].color = new Color(1, 1, 1, 0);
        score[1].color = new Color(1, 1, 1, 0);

        Dead.TransitionTo(2f);
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(1f);
        Panel.SetActive(true); // Появление кнопки рестарта
    }

    private void Final_panel_show()
    {
        Final_panel.SetActive(true);
        Final_panel_score.GetComponent<FinalScore>().StartCount();
    }
}
