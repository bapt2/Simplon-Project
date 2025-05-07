using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        GameManager.OnBonusScoreChange += UpdateScoreUI;
    }

    public void UpdateScoreUI(int value)
    {
        scoreText.text = $"Score: {value}";
    }
}
