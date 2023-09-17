using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTraversal : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;
    public GameObject credits;

    private void Start()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
        credits.SetActive(false);
    }
    public void OpenMenu()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
        credits.SetActive(false);
    }

    public void OpenLevelSelect()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
        credits.SetActive(false);
    }

    public void OpenCredits()
    {
        // designerblock https://www.1001fonts.com/designer-block-font.html
        mainMenu.SetActive(false);
        levelSelect.SetActive(false);
        credits.SetActive(true);
    }

    public void PlayLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            Application.Quit();
        }
    }

}
