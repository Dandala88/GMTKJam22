using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<float> scores;

    private void OnEnable()
    {
        EndGoal.OnCleared += UpdateScore;
    }

    private void OnDisable()
    {
        EndGoal.OnCleared -= UpdateScore;
    }

    private void UpdateScore(int level, float score)
    {
        string playerPrefsKey = "Level_" + level;
        if (PlayerPrefs.GetFloat(playerPrefsKey) > score)
            PlayerPrefs.SetFloat(playerPrefsKey, score);
        scores[level] = score;
    }

}
