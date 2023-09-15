using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PausingMidGame : MonoBehaviour
{
    public GameObject pauseMenuOverlay;

    private bool isPaused;


    private void Start()
    {
        pauseMenuOverlay.SetActive(false);
        isPaused = false;
    }
    private void PauseGame()
    {
        pauseMenuOverlay.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }

    private void UnpauseGame ()
    {
        pauseMenuOverlay.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OnEscapePress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
            }
        }
    }
}
