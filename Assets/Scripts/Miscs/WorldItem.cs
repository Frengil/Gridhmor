using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [SerializeField] float spawnForce;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] AudioClip pickUpSFX;

    private ItemData item;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Random.insideUnitCircle * spawnForce, ForceMode2D.Impulse);
    }

    public void setItem(ItemData i)
    {
        this.item = i;
        sprite.sprite = i.icon;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddItem(item);
            //Play SFX

            Destroy(gameObject);
        }
    }
}
