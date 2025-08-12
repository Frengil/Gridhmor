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

    public GameObject projectilePrefab;

    public void Trigger(
        Vector3 spawnPosition,
        Quaternion spawnRotation,
        Character.Team team)
    {

    }
}
