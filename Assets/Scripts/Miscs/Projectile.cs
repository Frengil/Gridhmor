using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage;
    private float speed;
    private float lifetime;

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
        int damage,
        float lifetime,
        float speed
        )
    {
        Destroy(gameObject, lifetime);
        this.speed = speed;
        this.team = team;
        this.damage = damage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();

        if (damagable != null && damagable.GetTeam() != this.team)
        {
            damagable.TakeDamage(damage);

        }
    }

}
