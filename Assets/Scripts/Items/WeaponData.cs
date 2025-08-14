using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "Item/Weapon")]
public class WeaponData : ItemData
{
    [Header("Weapon Data")]
    public float maxDamage;
    public float minDamage;
    public float range;
    public float attackRate;
    public float projectileLifeTime;
    public float projectileSpeed;

    public int weaponLevel;

    public Enchantment[] enchantments = new Enchantment[3];

    public GameObject projectilePrefab;

    public float[] calculateWeaponDamage()
    {
        float newMinDamage = minDamage;
        float newMaxDamage = maxDamage;
        foreach (Enchantment e in enchantments)
        {
            if (e.type == EnchantmentType.ADD_MIN_DAMAGE)
            {
                newMinDamage += e.value;
            }
            if (e.type == EnchantmentType.ADD_MAX_DAMAGE)
            {
                newMaxDamage += e.value;
            }
        }
        return new float[] { newMinDamage, newMaxDamage };
    }

    public float calculateAttackRate()
    {
        return attackRate;
    }

    public float calculateRange()
    {
        return range;
    }
}
