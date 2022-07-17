using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public static float timer;
    public static bool pauseTime;

    void Update()
    {
        if (!pauseTime)
        {
            timer += Time.deltaTime;
            text.text = ConvertSecondsToTimer(timer);
        }
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

    public static void ResetTime()
    {
        timer = 0;
    }
}
