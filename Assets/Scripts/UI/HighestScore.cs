using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class HighestScore : MonoBehaviour
{
    public Text current; // Показчиков очков на финальной таблице
    public Text highscore_text; // Лучший результат до этого
    public Text totalscore; // Весь результат за игру

    public AudioSource as_ofSFX;
    public AudioClip ac_beated;

    //public GameObject FinalPanelScript;

    //FinalScore finalscore;
    //private float timer = 0;
    private int high_score; 
    private int totalscore_text;
    public void StartHighScore()
    {
        //finalscore = FinalPanelScript.GetComponent<FinalScore>();

        totalscore_text = Convert.ToInt32(totalscore.text);
        high_score = PlayerPrefs.GetInt("HighestScore", 0);
        if (totalscore_text > high_score)
        {
            SetHigh();
        }
        
        highscore_text.text = Convert.ToString(high_score);

    }

    /*private void Updat()
    {
        if(Convert.ToInt32(current.text) == totalscore_text || Convert.ToInt32(current.text) > high_score)
        {
            if (Time.time > timer && clr < 0.8f)
            {
                timer = Time.time + 0.05f;
                clr += 0.01f;
                show.color = new Color(1, 1, 1, clr);
            }
            if (Convert.ToInt32(current.text) > high_score)
            {
                highscore_text.text = current.text;

                if(Convert.ToInt32(current.text) == totalscore_text)
                {
                    SetHigh();
                    high_score = PlayerPrefs.GetFloat("HighestScore", 0);
                }
            }
        }

        
    }*/

    private void SetHigh()
    {
        PlayerPrefs.SetInt("HighestScore", totalscore_text);
        as_ofSFX.PlayOneShot(ac_beated, 1.1f);
    }

    


}
