using System;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
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

    public enum Team
    {
        Player,
        Enemy
    }
}
