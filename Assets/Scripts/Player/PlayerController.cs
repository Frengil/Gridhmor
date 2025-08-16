using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [Header("Components")]
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private MouseUtilities mouseUtils;

    private Vector2 moveInput;

    public int sortingOrder { private set; get; }


    void Update()
    {
        Vector2 mousePosition = mouseUtils.getMouseDirection(this.transform.position);
        spriteRenderer.flipX = mousePosition.x < 0;
    }
    void FixedUpdate()
    {
        Vector2 velocity = moveInput * moveSpeed;
        rig.linearVelocity = velocity;
        sortingOrder = (int)(-transform.position.y * 1000);
        spriteRenderer.sortingOrder = sortingOrder;
    }

    public void onMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
