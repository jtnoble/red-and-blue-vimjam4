using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBoolControl : MonoBehaviour
{
    [SerializeField] private OpenDoor[] triggerOpen;
    [SerializeField] private bool isToggle = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            foreach(OpenDoor openDoor in triggerOpen)
            {
                openDoor.isOpen = !openDoor.isOpen;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isToggle && collision.CompareTag("Player")) 
        {
            foreach (OpenDoor openDoor in triggerOpen)
            {
                openDoor.isOpen = !openDoor.isOpen;
            }
        }
    }
}
