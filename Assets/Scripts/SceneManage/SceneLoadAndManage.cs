using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Static scene manager class
 */
public class SceneLoadAndManage : MonoBehaviour
{
    private SceneLoadAndManage() { //no-op
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex <= SceneManager.sceneCountInBuildSettings) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else 
        {
            LoadMainMenu();
        }
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
