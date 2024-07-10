using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UI_sound : MonoBehaviour
{
    public AudioMixerSnapshot silent;
    
    public AudioSource a_s;
    public AudioClip UI_sfx;
    public AudioClip UI_inPause;
    public AudioClip UI_outPause;
    public AudioClip UI_play;

    public void UI_Sound()
    {
        a_s.PlayOneShot(UI_sfx);
    }

    public void UI_InPause()
    {
        a_s.PlayOneShot(UI_inPause);
    }

    public void UI_OutPause()
    {
        a_s.PlayOneShot(UI_outPause);
    }

    public void UI_Play()
    {
        a_s.PlayOneShot(UI_play);
    }
    public void Transition_to_game()
    {
        silent.TransitionTo(1f);
    }

}
