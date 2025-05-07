using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="food", menuName ="FoodMenu/Food", order = 1)]
public class Food : ScriptableObject
{
    public int hungerPoint;
    public int malusPoint;
    public int ScorePoint;
}
