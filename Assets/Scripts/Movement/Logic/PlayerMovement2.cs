using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2 : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private MovementProfile profile;
    [SerializeField] private Rigidbody rb;

    [Header("Input")]
    [SerializeField] private InputAction moveAction;
    [SerializeField] private InputAction jumpAction;

    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private ThirdPersonCam thirdPersonCam;
    [SerializeField] private GameObject playerCollider; 

    [Header("Ground Check")]
    [SerializeField] private LayerMask whatIsGround;
    private bool isOnGround;
    private int groundContacts;
    private bool readyToJump = true;

    Vector2 moveInput;
    Vector3 moveDirection;
    
#region Processing
    private void Awake()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
            
        }
        rb.freezeRotation = true;
    }    

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }

    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        HandleDrag();
        HandleJump();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
#endregion

#region Direction Logic
    private void MovePlayer()
    {
        moveDirection = GetMoveDirection(moveInput);

        if(moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        if(profile.useOrientation && thirdPersonCam != null)
        {
            thirdPersonCam.RotatePlayer(moveDirection);
        }

        // on ground
        if (isOnGround)
        {
            rb.AddForce(
                moveDirection * profile.moveSpeed * 10f,
                ForceMode.Force
            );
        }
        // in air
        else
        {
            rb.AddForce(
                moveDirection.normalized * profile.moveSpeed * profile.airMultiplier * 10f,
                ForceMode.Force
            );
        }
    }

    private Vector3 GetMoveDirection(Vector2 input)
    {
        if(profile.mode == MovementMode.HorizontalOnly)
        {
            return new Vector3(input.x, 0f, 0f);
        }

        if(profile.useOrientation && orientation != null)
        {
            return orientation.forward * input.y + orientation.right * input.x;
        }

        return new Vector3(input.x, 0f, input.y);
    }
#endregion


#region Jumping
    private void HandleJump()
    {
        if(!profile.canJump) { return; }

        if(jumpAction.triggered && readyToJump && isOnGround)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), profile.jumpCoolDown);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * profile.jumpForce, ForceMode.Impulse); 
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
#endregion

#region Movement Settings
    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // limit speed if needed
        if(flatVelocity.magnitude > profile.moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * profile.moveSpeed;
            rb.linearVelocity = new Vector3(
                limitedVelocity.x, 
                rb.linearVelocity.y, 
                limitedVelocity.z
            );
        }
    }

    private void HandleDrag()
    {
        if (isOnGround)
        {
            rb.linearDamping = profile.groundDrag;
        }
        else
        {
            rb.linearDamping = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(IsGround(other.gameObject))
        {
            groundContacts++;
            isOnGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(IsGround(other.gameObject))
        {
            groundContacts--;
            groundContacts = Mathf.Max(groundContacts, 0);

            isOnGround = groundContacts > 0;
        }
    }

    private bool IsGround(GameObject obj)
    {
        return ((1 << obj.layer) & whatIsGround) != 0;
    }
#endregion

}
