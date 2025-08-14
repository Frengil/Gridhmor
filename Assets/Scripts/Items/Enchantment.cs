using UnityEngine;

[CreateAssetMenu(fileName = "Enchantments", menuName = "Item/Enchantment")]
public class Enchantment : ScriptableObject
{
    public int level;
    public EnchantmentType type;
    public int id;
    public string enchantmentName;
    public bool availableOnMeleeWeapon;
    public bool availableOnRangeWeapon;
    public bool availableOnArmor;
    public float value;
}
