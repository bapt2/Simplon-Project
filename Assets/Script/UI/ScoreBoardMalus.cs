using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoardMalus : MonoBehaviour
{
    public TextMeshProUGUI malusText;

    private void OnEnable()
    {
        GameManager.OnMalusScoreChange += UpdateMalusUI;
    }

    void UpdateMalusUI(int value)
    {
        malusText.text = $"Malus: {value}";
    }
}
