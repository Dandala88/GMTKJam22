using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoresMenu : MonoBehaviour
{
    public List<TextMeshProUGUI> scoreTexts;
    public LevelManager levelManager;

    private void OnEnable()
    {
        for (int i = 0; i < scoreTexts.Count; i++)
            scoreTexts[i].text = ConvertSecondsToTimer(levelManager.scores[i]);
    }

    public void UpdateScore(int level, float scoreText)
    {
        scoreTexts[level].text = ConvertSecondsToTimer(scoreText);
    }

    private string ConvertSecondsToTimer(float total)
    {
        int seconds = Mathf.RoundToInt(total % 60);
        int minConverted = Mathf.RoundToInt(total / 60);
        int minutes = Mathf.RoundToInt(minConverted % 60);

        return $"{LeadingZero(minutes)}:{LeadingZero(seconds)}";
    }

    private string LeadingZero(int val)
    {
        if (val < 10)
            return "0" + val.ToString();

        return val.ToString();
    }
}
