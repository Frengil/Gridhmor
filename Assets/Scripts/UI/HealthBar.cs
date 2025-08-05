using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character character;

    [SerializeField] private Image healthBar;

    void OnEnable()
    {
        character.onTakeDamage += UpdateHealthBar;
        character.onHeal += UpdateHealthBar;
    }

    void OnDisable()
    {
        character.onTakeDamage -= UpdateHealthBar;
        character.onHeal -= UpdateHealthBar;
    }

    public void UpdateHealthBar()
    {
        float healthPercent = (float)character.currentHp / (float)character.maxHp;
        healthBar.fillAmount = healthPercent;
    }

}
