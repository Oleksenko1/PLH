using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Profiling;
using System;
using System.Text;

public class FinalScore : MonoBehaviour
{

    public GameObject final_obj;
    public GameObject Final_panel;
    public GameObject HighestScore;
    public GameObject HighestScore2;
    private Text text1;
    private int finalscore = 0;
    public Animator anmtr;
    [SerializeField] private float countDuration;

    [NonSerialized] public float currentscore = 0;
    //private float timer = 0;


    private void Start() {
        text1 = GetComponent<Text>();

        text1.text = "0";


        Final_panel.SetActive(false);

        //Profiler.BeginSample("Countingscorefinal");
        
        //Profiler.EndSample();
    }

    public void StartCount()
    {
        finalscore = final_obj.GetComponent<PlayerDeath>().final_score_1;

        Invoke("Start_coroutine", 1.5f);
        anmtr.Play("Material");
    }

    private void Start_coroutine()
    {
        StartCoroutine(Increment_score());
    }

    private IEnumerator Increment_score()
    {
        var rate = Mathf.Abs(finalscore - currentscore) / countDuration;
        while (currentscore != finalscore)
        {
            currentscore = Mathf.MoveTowards(currentscore, finalscore, rate * Time.deltaTime);
            text1.text = ((int)currentscore).ToString();

            yield return null;

            //yield return new WaitForSeconds(faster);

        }

        HighestScore2.SetActive(true);
        HighestScore.GetComponent<HighestScore>().StartHighScore();
    }

    /*public void FixedUpdate()
    {
        text1.text = Math.Round(currentscore).ToString();

        currentscore = Mathf.Lerp(currentscore, finalscore, Time.deltaTime * speed);
    }


    public void StartCount()
    {
        StartCoroutine(Animated());
    }

    private IEnumerator Animated()
    {
        timer = 1/(finalscore/wait);
        while(currentscore<finalscore)
        {
            yield return new WaitForSeconds(timer);
            currentscore++;
        }
    }*/
}
