using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBoolControl : MonoBehaviour
{
    [SerializeField] private OpenDoor[] triggerOpen;
    [SerializeField] private bool isToggle = false;

    private SpriteRenderer spriteRenderer;

    public Sprite spriteUntoggled;
    public Sprite spriteToggled;

    private void Start()
    {
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
