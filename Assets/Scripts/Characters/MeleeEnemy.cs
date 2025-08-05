using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private int damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;

    protected override void attackTarget()
    {
        IDamagable damagable = target.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(damage);
        }
    }

    protected override bool canAttack()
    {
        return Time.time - lastAttackTime > attackRate;
    }

    protected override bool inAttackRange()
    {
        return targetDistance < attackRange;
    }
}
