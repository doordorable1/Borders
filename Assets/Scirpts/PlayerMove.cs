using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerMove : MonoBehaviour
{
    private const float gravity = -0.98f;

    private float moveSpeed = 4f;
    private float mouseSensitivity = 0.2f;
    [SerializeField] private Transform cameraTransform;

    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private float cameraPitch = 0f;
    private float verticalVelocity = 0f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        HandleLook();
        HandleMovement();
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
    
    private void HandleMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        move *= moveSpeed;
        verticalVelocity += gravity * Time.deltaTime;
        move.y = verticalVelocity;
        characterController.Move(move * Time.deltaTime);
    }

    private void HandleLook()
    {
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -89f, 89f);
        cameraTransform.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);
    }
    
}

