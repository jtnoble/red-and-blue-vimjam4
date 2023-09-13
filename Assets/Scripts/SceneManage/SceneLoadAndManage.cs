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
}
