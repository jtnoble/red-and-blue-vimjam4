using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicPersist : MonoBehaviour
{
    private static MusicPersist instance = null;

    public static MusicPersist Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
