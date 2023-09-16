using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBoolControl : MonoBehaviour
{
    [SerializeField] private OpenDoor[] triggerOpen;
    [SerializeField] private bool isToggle = false;

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    public Sprite spriteUntoggled;
    public Sprite spriteToggled;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            foreach(OpenDoor openDoor in triggerOpen)
            {
                openDoor.isOpen = !openDoor.isOpen;
            }
            spriteRenderer.sprite = spriteToggled;
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) 
        {
            if (!isToggle)
            {
                foreach (OpenDoor openDoor in triggerOpen)
                {
                    openDoor.isOpen = !openDoor.isOpen;
                }
            }
            spriteRenderer.sprite = spriteUntoggled;
        }
    }
}
