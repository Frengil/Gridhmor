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

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, i.range, hitLayerMask);
        if (hit.collider != null)
        {

            IDamagable damagable = hit.collider.GetComponent<IDamagable>();
            if (damagable != null)
            {
                int damage = (int)Random.Range(0, i.maxDamage - i.minDamage) + (int)i.minDamage; 
                damagable.TakeDamage(damage);
            }
        }
        //Raycast or in my case add a swoosh projectile
    }
}
