using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerClimb : MonoBehaviour
{
    [SerializeField] private float climbJumpDistance = 5f;
    [SerializeField] private LayerMask wall;
    [SerializeField] private float checkDistance = 0.5f;

    private CharacterController cc;
    private bool canClimb = false;
    private bool isClimbingInputActive = false;
    private Vector3 climbMove;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        climbMove = new Vector3(0, climbJumpDistance, 0);
    }

    private void Update()
    {
        CheckClimbableWall();
        if (canClimb && isClimbingInputActive)
        {
            Debug.Log($"{climbMove}");
            cc.Move(Vector3.up * climbJumpDistance * Time.deltaTime);
        }
    }

    public void OnClimb(InputAction.CallbackContext context)
    {
        if (context.performed)
            isClimbingInputActive = true;
        else if (context.canceled)
            isClimbingInputActive = false;
    }

    private void CheckClimbableWall()
    {
        Vector3 direction = transform.forward;
        RaycastHit hit;
        canClimb = Physics.Raycast(transform.position, direction, out hit, checkDistance, wall);
        Color rayColor = canClimb ? Color.red : Color.green;
        Debug.DrawRay(transform.position, direction * checkDistance, rayColor, 0.1f);
    }
}
