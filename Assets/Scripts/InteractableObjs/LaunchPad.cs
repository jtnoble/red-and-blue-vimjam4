using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    [SerializeField] private float launchForce = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Trigger LaunchPad");
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            playerRb.AddForce(Vector2.up * launchForce);
        }
    }
}
