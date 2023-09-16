using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    [SerializeField] private float launchForce = 1f;

    private bool canLaunch = true;
    private Animator anim;
    private AudioSource audioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canLaunch)
        {
            Debug.Log("Trigger LaunchPad");
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            playerRb.AddForce(Vector2.up * launchForce);
            audioSource.Play();
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        anim.SetTrigger("Launch");
        canLaunch = false;
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Return");
        canLaunch = true;
    }


}
