using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float speed;

    [Header("Salto")]
    [SerializeField] private float jumpForce;

    [SerializeField] private Transform cameraTransform;

    private Vector2 input;
    private bool isGrounded;
    private Rigidbody rb;

    private void Update()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(input.x, 0, input.y);
        rb.MovePosition(rb.position + speed * direction * Time.deltaTime);
    }

}
