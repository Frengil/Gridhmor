using UnityEngine;
using TMPro;
public class ItemToolTipUI : MonoBehaviour
{
    [SerializeField] private GameObject toolTipContainer;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;


    public void disableToolTip()
    {
        toolTipContainer.SetActive(false);
    }

    public void enableToolTip(ItemData item)
    {
        toolTipContainer.SetActive(true);
        itemName.text = item.DisplayName;
        itemDescription.text = item.Description;
    }

}
