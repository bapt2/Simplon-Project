using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int hunger;
    public int scorePoints;
    public int malusScorePoint;

    public float hungerTime;

    public bool inCoolDown;
    public bool inWater;

    public GameObject scoreBoard;
    public GameObject gameOverMenu;
    public TextMeshProUGUI deathScore;

    public static event Action<int> OnBonusScoreChange;
    public static event Action<int> OnMalusScoreChange;
    public static event Action<int> OnHungerChange;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Update()
    {
        if (hunger <= 0)
            GameOver();
        if (!inCoolDown)
            StartCoroutine(HungerDecrease());
        if (hunger > 100)
            hunger = 100;
    }

    void GameOver()
    {
        scoreBoard.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
        PlayerMovement.instance.enabled = false;
        deathScore.text = $"Score: {scorePoints - malusScorePoint}";
    }

    public void AddBonusScore(int amount)
    {
        scorePoints += amount;
        OnBonusScoreChange?.Invoke(scorePoints);
    }

    public void AddMalusScore(int amount)
    {
        malusScorePoint += amount;
        OnMalusScoreChange?.Invoke(malusScorePoint);
    }

    public void ChangeHunger(int amount)
    {
        hunger += amount;
        if (hunger > 100)
            hunger = 100;
        OnHungerChange?.Invoke(hunger);
    }

    public void ToggleWaterState()
    {
        inWater = !inWater;
        Debug.Log(inWater);
    }

    IEnumerator HungerDecrease()
    {
        inCoolDown = true;
        if (!inWater)
        {
            yield return new WaitForSecondsRealtime(hungerTime);
            ChangeHunger(-1);
        }
        else
        {
            yield return new WaitForSecondsRealtime(hungerTime / 2);
            ChangeHunger(-1);
        }
        inCoolDown = false;
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
