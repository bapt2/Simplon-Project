using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHandler : MonoBehaviour
{
    public Food food;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("test de collision");
            CollecteFood();
        }
    }

    public void CollecteFood()
    {
        if (food.hungerPoint != 0)
            GameManager.instance.ChangeHunger(food.hungerPoint);
        if (food.ScorePoint != 0)
            GameManager.instance.AddBonusScore(food.ScorePoint);
        if (food.malusPoint != 0)
            GameManager.instance.AddMalusScore(food.malusPoint);

        Destroy(gameObject);
    }
}
