using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 10f;

    private Rigidbody _rb;
    private Vector2 _moveInput;
    


    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    private void Update()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y).normalized;
        _rb.linearVelocity = new Vector3(moveDirection.x * _moveSpeed, _rb.linearVelocity.y, moveDirection.z * _moveSpeed);
        
        // Rotate to face movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}