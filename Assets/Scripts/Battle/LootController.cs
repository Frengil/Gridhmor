using UnityEngine;

public class LootController : MonoBehaviour
{

    public static LootController instance;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    [SerializeField] protected ItemData[] dropableItems;
    [SerializeField] protected GameObject dropItemPrefab;
    [SerializeField] protected GameObject goldItemPrefab;   

    [SerializeField] private LevelController levelController;
    public void createLoot(Enemy enemy)
    {
        for (int i = 0; i < dropableItems.Length; i++)
        {
            GameObject o = Instantiate(dropItemPrefab, enemy.gameObject.transform.position, Quaternion.identity);
            o.GetComponent<WorldItem>().setItem(dropableItems[i]);
        }
    }

    public void createGoldLoot(int amount, Transform position)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject o = Instantiate(goldItemPrefab, position.position, Quaternion.identity);

        }
    }
}
