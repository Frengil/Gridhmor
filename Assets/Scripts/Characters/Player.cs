using UnityEngine;

public class Player : Character
{
    public static Player instance;
    [SerializeField] public EquipController equipController;
    void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
