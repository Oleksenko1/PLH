using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseInGame : MonoBehaviour
{
    public GameObject PausePanel;

    private GameObject pausepanel;

    PanelScript panelscript;

    public void Pause()
    {

        PausePanel.SetActive(true);

        gameObject.SetActive(false);
    }
    
}
