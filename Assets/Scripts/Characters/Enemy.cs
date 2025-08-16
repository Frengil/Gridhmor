using UnityEngine;

public abstract class Enemy : Character
{
    public enum State
    {
        Idle,
        Attack,
        Chase
    }

    protected State curState;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float chaseDistance;
    [SerializeField] protected int goldAmountToDrop;

    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    protected GameObject target;

    protected float lastAttackTime;
    protected float targetDistance;

    protected virtual void Start()
    {
        target = FindAnyObjectByType<Player>().gameObject;
    }

    protected virtual void Update()
    {
        spriteRenderer.flipX = getTargetDirection().x < 0;
        targetDistance = Vector2.Distance(this.gameObject.transform.position, target.transform.position);
        switch (curState)
        {
            case State.Idle: IdleUdate(); break;
            case State.Chase: ChaseUpdate(); break;
            case State.Attack: AttackUpdate(); break;
        }
    }

    public void setDifficultyOfEnemy(int difficulty)
    {

    }

    void IdleUdate()
    {
        if (targetDistance < chaseDistance)
        {
            ChangeState(State.Chase);
        }
    }
    void ChaseUpdate()
    {
        if (inAttackRange())
        {
            ChangeState(State.Attack);
        }
        else if (targetDistance > chaseDistance)
        {
            ChangeState(State.Idle);
        }
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    void AttackUpdate()
    {
        if (chaseDistance < targetDistance)
        {
            ChangeState(State.Idle);
        }
        else if (!inAttackRange())
        {
            ChangeState(State.Chase);
        }

        if (canAttack())
        {
            lastAttackTime = Time.time;
            attackTarget();

        }
    }

    protected virtual bool canAttack()
    {
        return false;
    }

    void ChangeState(Enemy.State newState)
    {

        this.curState = newState;
    }

    protected virtual bool inAttackRange()
    {
        return false;
    }

    protected virtual void attackTarget()
    {

    }

    public override void Die()
    {
        dropItems();
        Destroy(gameObject);
    }

    protected void dropItems()
    {
        LootController.instance.createGoldLoot(this.goldAmountToDrop, this.transform);
        LootController.instance.createLoot(this);

    }

    protected Vector2 getTargetDirection()
    {
        return (target.transform.position - transform.position).normalized;
    }
}
