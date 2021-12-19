using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int stars = 1000;
    [SerializeField] private TextMeshProUGUI starText;

    private void Start()
    {
        starText.text = stars.ToString();
    }

    private void UpdateStarCount()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateStarCount();
    }

    public void SpendStars(int amount)
    {
        stars -= amount;
        UpdateStarCount();
    }

    public int GetStarCount()
    {
        return stars;
    }
}