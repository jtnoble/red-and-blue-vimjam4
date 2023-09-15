using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimation : MonoBehaviour
{
    // Imported Fields
    private Rigidbody2D rb2d;

    // Movement Fields
    private Vector2 movement;
    private bool isJumping;

    // Serialized Fields
    [SerializeField] private float moveSpeed = 200f;
    [SerializeField] private float jumpForce = 0f;

    private void Start()
    {
        rb2d = GetComponentInChildren<Rigidbody2D>();
        StartCoroutine(Automate());
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

    private IEnumerator Automate()
    {
        movement = new Vector2(1, 0);
        yield return new WaitForSeconds(Random.Range(4f, 6f));
        movement = new Vector2(-1, 0);
        yield return new WaitForSeconds(Random.Range(4f, 6f));
        StartCoroutine(Automate());
    }
}
