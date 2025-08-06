using UnityEngine;
[CreateAssetMenu(fileName ="Item Data",menuName ="Item/Generic Items")]
public class ItemData : ScriptableObject
{
    public string DisplayName;
    public string Description;
    public Sprite icon;
    public int MaxStackSize = 1;

    public GameObject EquipPrefab;
}
