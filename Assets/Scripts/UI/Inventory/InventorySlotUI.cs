using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class InventorySlotUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;

    private ItemSlot itemSlot;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (itemSlot.item != null)
        {
            Inventory.instance.useItem(itemSlot);
        }
    }

    public void setItemSlot(ItemSlot slot)
    {
        this.itemSlot = slot;
        if (itemSlot.item == null)
        {
            icon.enabled = false;
            quantityText.text = "";

        }
        else
        {
            icon.enabled = true;

            icon.sprite = slot.item.icon;
            quantityText.text = slot.quantity > 1 ? slot.quantity.ToString() : "";
        }
    }
}
