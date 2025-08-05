using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour, IDamagable
{
    public String DisplayName;
    public int currentHp;
    public int maxHp;
    [SerializeField] protected Team team;

    [Header("Audio")]
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip hitSFX;


    public event UnityAction onTakeDamage;
    public event UnityAction onHeal;

    public virtual void Die() { }

    public Team GetTeam()
    {
        return team;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHp -= damage;
        audioSource.PlayOneShot(hitSFX);
        onTakeDamage?.Invoke();

        if (currentHp < 0)
        {
            Die();
        }
    }

    public virtual void Heal(int healAmount)
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
