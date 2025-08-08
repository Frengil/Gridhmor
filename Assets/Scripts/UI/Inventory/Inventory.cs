using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemData[] starterItems;
    [SerializeField] private int inventorySize;

    private ItemSlot[] slots;

    public InventoryUI inventoryUI;

    public static Inventory instance;

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

    void Start()
    {
        slots = new ItemSlot[inventorySize];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
        }

        for (int i = 0; i < starterItems.Length; i++)
        {
            AddItem(starterItems[i]);
        }
    }

    public void AddItem(ItemData item)
    {

    }

    public void RemoveItem(ItemSlot slot)
    {

    }

    ItemSlot findSlotWithItem(ItemData item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null && slots[i].item == item && slots[i].item.MaxStackSize <= slots[i].quantity)
            {
                return slots[i];
            }
        }
        return null;
    }

    ItemSlot getEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                return slots[i];
            }
        }
        return null;
    }

    public void useItem(ItemSlot slot)
    {

    }

    public bool hasItem(ItemData item)
    {
        return false;
    }
}
