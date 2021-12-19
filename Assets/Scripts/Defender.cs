using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int defenderCost = 100;

    public void CreateStars(int income)
    {
        FindObjectOfType<StarDisplay>().AddStars(income);
    }

    public int GetDefenderCost()
    {
        return defenderCost;
    }
}