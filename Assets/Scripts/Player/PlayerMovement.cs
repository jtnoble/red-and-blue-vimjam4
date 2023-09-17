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

    // Serialized Fields
    [SerializeField] private float moveSpeed = 0f;

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


    public void OnMove(InputAction.CallbackContext context) {
        movement.x = context.ReadValue<Vector2>().x;
    }
}
