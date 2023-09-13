using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool isOpen = false;

    [SerializeField] private Transform doorObjTransform;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;

    [SerializeField] private float openTime = 0f;
    [SerializeField] private float closeTime = 0f;

    private void FixedUpdate()
    {
        if (isOpen) Open();
        else Close();
    }

    private void Open()
    {
        doorObjTransform.position = Vector2.MoveTowards(doorObjTransform.position, endPos.position, openTime * Time.fixedDeltaTime);
    }

    private void Close()
    {
        doorObjTransform.position = Vector2.MoveTowards(doorObjTransform.position, startPos.position, closeTime * Time.fixedDeltaTime);
    }
}
