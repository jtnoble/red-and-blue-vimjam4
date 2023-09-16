using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicPersist : MonoBehaviour
{
    private static MusicPersist instance = null;
    private static AudioSource audioSource;

    public static bool levelStarted = false;
    public static MusicPersist Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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

    private void Update()
    {
        if (levelStarted)
        {
            audioSource.volume = 0.7f;
        }
        levelStarted = false;
    }

    public static IEnumerator EndLevel()
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0.1)
        {
            audioSource.volume -= startVolume * Time.deltaTime / 0.25f;

            yield return null;
        }
        yield return new WaitForSeconds(2);
        startVolume = audioSource.volume;

        while (audioSource.volume < 0.7)
        {
            audioSource.volume += startVolume * Time.deltaTime / .25f;

            yield return null;
        }
    }
}
