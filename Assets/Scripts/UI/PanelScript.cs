using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    public AudioMixerGroup MasterMixer, SFXMixer, UIMixer, MusicMixer;

    public Slider Master_sl, SFX_sl, UI_sl, Music_sl;

    public GameObject PauseButton;

    public AudioMixerSnapshot Normal;
    public AudioMixerSnapshot InMenu;
    private void Start()
    {
        Master_sl.value = PlayerPrefs.GetFloat("MasterVolume_float", 1);
        Music_sl.value = PlayerPrefs.GetFloat("MusicVolume_float", 1);
        SFX_sl.value = PlayerPrefs.GetFloat("SFXVolume_float", 1);
        UI_sl.value = PlayerPrefs.GetFloat("UIVolume_float", 1);

        ChangeMasterVolume(Master_sl.value);
        ChangeMusicVolume(Music_sl.value);
        ChangeSFXVolume(SFX_sl.value);
        ChangeUIVolume(UI_sl.value);


        gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        PauseButton.SetActive(true);

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;

        InMenu.TransitionTo(0.5f);
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
        Normal.TransitionTo(1.5f);
    }
    public void ChangeMasterVolume(float vol)
    {
        MasterMixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, vol));

        PlayerPrefs.SetFloat("MasterVolume_float", vol);
    }

    public void ChangeMusicVolume(float vol)
    {
        MusicMixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, vol));

        PlayerPrefs.SetFloat("MusicVolume_float", vol);
    }

    public void ChangeSFXVolume(float vol)
    {
        SFXMixer.audioMixer.SetFloat("SFXVolume", Mathf.Lerp(-80, 0, vol));

        PlayerPrefs.SetFloat("SFXVolume_float", vol);
    }

    public void ChangeUIVolume(float vol)
    {
        UIMixer.audioMixer.SetFloat("UIVolume", Mathf.Lerp(-80, 0, vol));

        PlayerPrefs.SetFloat("UIVolume_float", vol);
    }
}
