using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckpointControl : MonoBehaviour
{
    public Transform startPos;

    public GameObject playerIndicator;
    public Rigidbody2D rb2d;


    private Vector2 savedVelocity;
    private bool hasCheckpoint;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerIndicator.SetActive(false);
        hasCheckpoint = false;
    }

    private void SaveCheckpoint()
    {
        if (!playerIndicator.activeSelf)
        {
            playerIndicator.SetActive(true);
        }
        hasCheckpoint = true;
        playerIndicator.transform.position = transform.position;
        transform.position = startPos.position;
        // Save rb velocity then reset velocity
        savedVelocity = rb2d.velocity;
        rb2d.velocity = Vector2.zero;

    }

    private void LoadCheckpoint()
    {
        if (!hasCheckpoint)
        {
            Debug.Log("No checkpoint!");
            return;
        }
        transform.position = playerIndicator.transform.position;
        playerIndicator.SetActive(false);
        hasCheckpoint = false;
        rb2d.velocity = savedVelocity;

    }

    public void OnSaveCheckpointButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SaveCheckpoint();
        }
    }

    public void OnLoadCheckpointButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            LoadCheckpoint();
        }
    }
}
