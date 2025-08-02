using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
   [SerializeField] private float moveSpeed;
   [Header("Components")]
   [SerializeField] private Rigidbody2D rig;
   [SerializeField] private SpriteRenderer spriteRenderer;

   private Vector2 moveInput;

    void FixedUpdate()
    {
        Vector2 velocity = moveInput*moveSpeed;
        rig.linearVelocity=velocity;
    }
}
