using UnityEngine;

public class Enemy : Character
{
    public enum State
    {
        Idle,
        Attack,
        Chase
    }

    private State curState;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float attackDistance;

    private GameObject target;

    private float lastAttackTime;
    private float targetDistance;

    void Start()
    {
        target = FindAnyObjectByType<Player>().gameObject;
    }

    void Update()
    {

        targetDistance = Vector2.Distance(this.gameObject.transform.position, target.transform.position);
        switch (curState)
        {
            case State.Idle: IdleUdate(); break;
            case State.Chase: ChaseUpdate(); break;
            case State.Attack: AttackUpdate(); break;
        }
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

    }

    void ChangeState(Enemy.State newState)
    {

        this.curState = newState;
    }

    bool inAttackRange()
    {
        return targetDistance <= attackDistance;
    }
}
