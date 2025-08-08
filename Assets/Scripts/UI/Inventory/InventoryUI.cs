using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySlotUI[] slots;
    [SerializeField] public ItemToolTipUI toolTip;


    public void updateUI(ItemSlot[] itemSlots)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].setItemSlot(itemSlots[i]);
        }
    }
}
