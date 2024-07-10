using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    private Text text;
    int score_tablo = 0;
    //public Text score;

    private void Awake() {
        text = GetComponent<Text>();

        text.text = "0";
    }

    public void Add_score(int add)
    {
        score_tablo += add;
        text.text = score_tablo.ToString();
    }

    /*private void Update() // Обновляет очки игрока 
    { 
         text.text = score.text;
    }*/
}
