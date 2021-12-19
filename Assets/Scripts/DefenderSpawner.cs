using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender _defender;
    private StarDisplay _starDisplay;
    private bool _isDefenderPassed;

    private void Start()
    {
        _starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void SetSelectedDefender(Defender defender)
    {
        _defender = defender;
        _isDefenderPassed = true;
    }

    private void OnMouseDown()
    {
        if (!_isDefenderPassed) return;

        if (_starDisplay.GetStarCount() >= _defender.GetDefenderCost())
        {
            SpawnDefender(GetSquareClicked());
            _starDisplay.SpendStars(_defender.GetDefenderCost());
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        worldPos = SnapToGrid(worldPos);
        return worldPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(_defender, worldPos, Quaternion.identity);
    }
}