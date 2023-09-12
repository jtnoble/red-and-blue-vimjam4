using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckpointControl : MonoBehaviour
{
    public Transform startPos;

    public GameObject playerIndicator;
    public Rigidbody2D rb2d;
    public Collider2D collider2d;

    [SerializeField] private float teleportSpeed = 1f;

    private Vector2 savedVelocity;
    private bool hasCheckpoint;
    private bool moveTowardsStart;
    private bool moveTowardsCheckpoint;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        playerIndicator.SetActive(false);
        hasCheckpoint = false;
    }

    private void Update()
    {
        if (moveTowardsStart)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos.position, teleportSpeed * Time.deltaTime);
            if ((transform.position - startPos.transform.position).sqrMagnitude <= 0.1)
            {
                collider2d.enabled = true;
                moveTowardsStart = false;
                rb2d.isKinematic = false;
            }
        }

        else if (moveTowardsCheckpoint)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerIndicator.transform.position, teleportSpeed * Time.deltaTime);
            if ((transform.position - playerIndicator.transform.position).sqrMagnitude <= 0.1)
            {
                playerIndicator.SetActive(false);
                collider2d.enabled = true;
                moveTowardsCheckpoint = false;
                rb2d.isKinematic = false;
            }
        }
    }

    private void SaveCheckpoint()
    {
        if (!playerIndicator.activeSelf)
        {
            playerIndicator.SetActive(true);
        }
        hasCheckpoint = true;
        playerIndicator.transform.position = transform.position;

        //transform.position = startPos.position;
        collider2d.enabled = false;
        rb2d.isKinematic = true;
        moveTowardsStart = true;

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
        // transform.position = playerIndicator.transform.position;
        collider2d.enabled = false;
        rb2d.isKinematic = true;
        moveTowardsCheckpoint = true;
        
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
