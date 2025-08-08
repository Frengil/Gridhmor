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
        ItemSlot slot = findSlotWithItem(item);
        if (slot != null)
        {
            slot.quantity++;
            inventoryUI.updateUI(slots);
            return;
        }

        slot = getEmptySlot();
        if (slot != null)
        {
            slot.item = item;
            slot.quantity = 1;
        }
        else
        {
            //Iventory is full
        }
        inventoryUI.updateUI(slots);
    }

    public void RemoveItem(ItemSlot slot)
    {
        if (slot == null)
        {
            return;
        }

        slot.quantity--;
        if (slot.quantity <= 0)
        {
            slot.item = null;
            slot.quantity = 0;
        }

        inventoryUI.updateUI(slots);
    }

    ItemSlot findSlotWithItem(ItemData item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null && slots[i].item == item && slots[i].item.MaxStackSize < slots[i].quantity)
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
            if (slots[i].item == null)
            {
                return slots[i];
            }
        }
        return null;
    }

    public void useItem(ItemSlot slot)
    {
        if (slot.item == null)
        {
            return;
        }

        if (slot.item is WeaponData)
        {
            Player.instance.equipController.EquipLeftHand(slot.item);
        }
    }

    public bool hasItem(ItemData item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null && slots[i].item == item && slots[i].quantity > 0)
            {
                return true;
            }
        }
        return false;
    }
}
