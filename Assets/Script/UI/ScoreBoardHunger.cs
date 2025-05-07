using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoardHunger : MonoBehaviour
{
    public TextMeshProUGUI hungerText;

    private void OnEnable()
    {
        GameManager.OnHungerChange += UpdateHungerUI;
    }

    void UpdateHungerUI(int value)
    {
        hungerText.text = $"Hunger: {value}";
    }
}
