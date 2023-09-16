using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletionProgression : MonoBehaviour
{
    public CompletionBall completionBall1;
    public CompletionBall completionBall2;
    public GameObject levelCompleteUI;
    public AudioSource audioSource;

    private bool hasFinished = false;

    private void Start()
    {
        levelCompleteUI.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        MusicPersist.levelStarted = true;
    }
    private void Update()
    {
        if (completionBall1.hasFinished && completionBall2.hasFinished && !hasFinished)
        {
            hasFinished = true;
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        levelCompleteUI.SetActive(true);
        StartCoroutine(MusicPersist.EndLevel());
        audioSource.Play();
    }
}
