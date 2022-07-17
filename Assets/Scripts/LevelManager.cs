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
        if(PlayerPrefs.HasKey(playerPrefsKey))
        {
            float storedScore = PlayerPrefs.GetFloat(playerPrefsKey);
            float best = 0f;
            if (storedScore > score)
            {
                PlayerPrefs.SetFloat(playerPrefsKey, score);
                best = score;
            }
            else
            {
                best = storedScore;
            }

            scores[level] = best;
        }
        else
        {
            PlayerPrefs.SetFloat(playerPrefsKey, score);
            scores[level] = score;
        }

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
