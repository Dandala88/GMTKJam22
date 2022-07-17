using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<string> scores;

    private void OnEnable()
    {
        EndGoal.OnCleared += UpdateScore;
    }

    private void OnDisable()
    {
        EndGoal.OnCleared -= UpdateScore;
    }

    private void UpdateScore(int level, string score)
    {
        scores[level] = score;
    }

}
