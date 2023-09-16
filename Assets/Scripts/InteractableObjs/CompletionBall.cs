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
    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    private Collider2D collide;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collide = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasFinished = true;
            spriteRenderer.sprite = newSprite;
            collide.enabled = false;
            Destroy(collision.gameObject.GetComponent<PlayerMovement>());
            Destroy(collision.gameObject.GetComponent<CheckpointControl>());
        }
    }
}
