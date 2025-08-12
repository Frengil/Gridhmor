using UnityEngine;

public class MeleeEquipItem : EquipItem
{
    [SerializeField] private LayerMask hitLayerMask;
    [SerializeField] private Animator anim;
    private Transform muzzle;

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

        anim.SetTrigger("Attack");

        GameObject projectile = Instantiate(i.projectilePrefab, transform.position, transform.rotation);
        projectile.GetComponent<Projectile>().initProjectile(
            Character.Team.Player,
          (int)i.minDamage,
          (int)i.maxDamage,
           i.projectileLifeTime,
           i.projectileSpeed
            );
    }
}
