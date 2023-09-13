using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Destroy PlayerMovement/CheckpointControl and set hasFinished to true on trigger.
 */
public class CompletionBall : MonoBehaviour
{
    public bool hasFinished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasFinished = true;
            Destroy(collision.gameObject.GetComponent<PlayerMovement>());
            Destroy(collision.gameObject.GetComponent<CheckpointControl>());
        }
    }
}
