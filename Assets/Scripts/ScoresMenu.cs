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
            scoreTexts[i].text = levelManager.scores[i];
    }

    public void UpdateScore(int level, string scoreText)
    {
        scoreTexts[level].text = scoreText;
    }
}
