using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody _rb;
    private Vector2 _moveInputs;
    [SerializeField] private Transform cameraTransform;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInputs = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 forward = new Vector3(cameraTransform.forward.x, 0f, cameraTransform.forward.z).normalized;
        Vector3 right = new Vector3(cameraTransform.right.x, 0f, cameraTransform.right.z).normalized;

        Vector3 moveDirection = (forward * _moveInputs.y + right * _moveInputs.x).normalized;
        Vector3 velocity = moveDirection * speed;

        _rb.AddForce(velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lava"))
        {
            SceneManager.LoadScene("Defeat");
        }
        else if (other.CompareTag("Win"))
        {
            SceneManager.LoadScene("Victory");
        }
    }
}

