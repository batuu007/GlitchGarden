using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] private Defender defender;
    [SerializeField] private SpriteRenderer[] buttons;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color highlightedColor;
    private int _defenderIndex = 0;

    private void OnMouseDown()
    {
        SetToDefaultColor();

        buttons[_defenderIndex].color = highlightedColor;

        PassDefenderToDefenderSpawner();
    }

    private void SetToDefaultColor()
    {
        foreach (SpriteRenderer button in buttons)
        {
            button.color = defaultColor;
        }
    }

    private void PassDefenderToDefenderSpawner()
    {
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defender);
    }
}