using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTraversal : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;

    private void Start()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }
    public void OpenMenu()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void OpenLevelSelect()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void PlayLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
