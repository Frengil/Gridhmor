using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int minDamage;
    private int maxDamage;
    private float speed;

    private Character.Team team;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = transform.up * speed;
    }

    public void initProjectile(
        Character.Team team,
        int minDamage,
        int maxDamage,
        float lifetime,
        float speed
        )
    {
        Destroy(gameObject, lifetime);
        this.speed = speed;
        this.team = team;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();

        if (damagable != null && damagable.GetTeam() != this.team)
        {

            int damage = Random.Range(0, this.maxDamage - this.minDamage) + this.minDamage;
            damagable.TakeDamage(damage);

        }
    }

}
