using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LiveDisplay : MonoBehaviour
{
    [SerializeField] private int lives = 5;
    [SerializeField] private int damage = 1;
    [SerializeField] private TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();
        if (lives <= 0)
            FindObjectOfType<LevelLoader>().LoadGameOverScene();
    }
}