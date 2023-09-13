using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManagerInputs : MonoBehaviour
{
    public void OnReset(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneLoadAndManage.ReloadScene();
        }
    }
}
