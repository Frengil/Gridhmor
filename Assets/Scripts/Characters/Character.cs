using System;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour, IDamagable
{
    public String DisplayName;
    public int currentHp;
    public int maxHp;
    [SerializeField] private Team team;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitSFX;


    public event UnityAction onTakeDamage;
    public event UnityAction onHeal;

    public virtual void Die() { }

    public Team GetTeam()
    {
        return team;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        audioSource.PlayOneShot(hitSFX);
        onTakeDamage?.Invoke();

        if (currentHp < 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHp += healAmount;
        currentHp = Math.Min(currentHp, maxHp);
        onHeal?.Invoke();
    }

    public enum Team
    {
        Player,
        Enemy
    }
}
