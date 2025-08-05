using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image healthBar;

    public void SetNameText(string text)
    {
        nameText.text = text;
    }

    public void UpdateHealthBar()
    {
        float healthPercent = (float)character.currentHp / (float)character.maxHp;
        healthBar.fillAmount = healthPercent;
    }

}
