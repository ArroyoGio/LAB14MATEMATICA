using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f; 
    private Rigidbody _rb;
    private Vector2 _moveInputs;

    void Start()
    {
        _rb = GetComponent<Rigidbody>(); 
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInputs = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_moveInputs.x, 0f, _moveInputs.y);
        _rb.AddForce(movement * speed);
    }
}

