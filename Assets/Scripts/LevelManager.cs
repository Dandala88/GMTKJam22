using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<float> scores;

    private void Start()
    {
        InitializeScores();
    }

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
        var playerPrefs = PlayerPrefs.GetFloat(playerPrefsKey);
        if (PlayerPrefs.GetFloat(playerPrefsKey) > score || !PlayerPrefs.HasKey(playerPrefsKey))
            PlayerPrefs.SetFloat(playerPrefsKey, score);
        scores[level] = score;
    }

    private void InitializeScores()
    {
        int i = 0;
        while (PlayerPrefs.HasKey("Level_" + i))
        {
            scores[i] = PlayerPrefs.GetFloat("Level_" + i);
            i++;
        }
    }

}
