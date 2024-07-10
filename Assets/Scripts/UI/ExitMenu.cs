using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    public void Menu() // Перезапускает уровень
    {
        SceneManager.LoadScene("Menu");
    }
}
