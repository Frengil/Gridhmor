using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EquipController : MonoBehaviour
{
    private EquipItem leftHandItem;
    private GameObject leftHandItemGo;

    private bool useLeftHand;




    [Header("Components")]
    [SerializeField] private Transform leftHandItemOrigin;
    [SerializeField] private MouseUtilities mouseUtils;

    void Update()
    {
        Vector2 mouseDir = mouseUtils.getMouseDirection(transform.position);
        transform.up = mouseDir;

        if (hasLeftHAndItemEquiped())
        {
            if (useLeftHand && !EventSystem.current.IsPointerOverGameObject())
            {
                leftHandItem.onUse();
            }
        }
    }

    public void EquipLeftHand(ItemData item)
    {
        if (hasLeftHAndItemEquiped())
        {
            UnEquipLeftHand();
        }
        leftHandItemGo = Instantiate(item.EquipPrefab, leftHandItemOrigin);
        leftHandItem = leftHandItemGo.GetComponent<EquipItem>();

    }

    public void UnEquipLeftHand()
    {
        if (leftHandItemGo != null)
        {
            Destroy(leftHandItemGo);
        }
        leftHandItem = null;
    }

    public bool hasLeftHAndItemEquiped()
    {
        return leftHandItem != null;
    }

    public void OnUseInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            useLeftHand = true;
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            useLeftHand = false;
        }
    }
}
