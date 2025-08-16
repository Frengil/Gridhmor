using UnityEngine;

public class GoldItem : MonoBehaviour
{
    [SerializeField] float spawnForce;
    [SerializeField] AudioClip pickUpSFX;

    private ItemData item;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Random.insideUnitCircle * spawnForce, ForceMode2D.Impulse);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.addGold(1);
            AudioManager.instance.playPlayerSound(pickUpSFX);

            Destroy(gameObject);
        }
    }
}
