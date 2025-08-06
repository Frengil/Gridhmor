using UnityEngine;

public class MeleeEquipItem : EquipItem
{
    [SerializeField] private LayerMask hitLayerMask;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform muzzle;

    private float lastAttackTime;

    [SerializeField] private AudioClip audioSFX;

    public override void onUse()
    {
        WeaponData i = item as WeaponData;
        if (Time.time - lastAttackTime < i.attackRate)
        {
            return;
        }

        lastAttackTime = Time.time;

        //Play animation

        //Raycast or in my case add a swoosh projectile
    }
}
