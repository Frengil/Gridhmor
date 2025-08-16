using UnityEngine;

public class DynamicSortingOrder : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int shift;

    void FixedUpdate()
    {

        spriteRenderer.sortingOrder = (int)(-transform.position.y * 1000)-shift;
    }
}
