using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletionProgression : MonoBehaviour
{
    public CompletionBall completionBall1;
    public CompletionBall completionBall2;

    private bool hasFinished = false;
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
        Debug.Log("Finished Level!");
    }
}
