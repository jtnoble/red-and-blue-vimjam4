using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    // Imported Fields
    private Rigidbody2D rb2d;

    // Movement Fields
    private Vector2 movement;
    private bool isJumping;

    // Serialized Fields
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float jumpForce = 0f;

    private void Start()
    {
        rb2d = GetComponentInChildren<Rigidbody2D>();
    }
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //rb2d.AddForce(movement * moveSpeed);
        rb2d.AddForce(movement * moveSpeed);
    }

    private void Jump()
    {
        Debug.Log("jump");
        rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void OnMove(InputAction.CallbackContext context) {
        movement.x = context.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isJumping = true;
            Jump();
        }
        else if (context.canceled)
        {
            isJumping = false;
        }
    }
}
