using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{
    [Header("Animation")]
    private Animator animator; 

    [Header("Input Actions")]
    [SerializeField] private InputAction moveAction;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void Update()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        if (moveAction.IsPressed())
        {
            animator.SetBool("isRunning", true);
        }

        if (!moveAction.IsPressed())
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void Jump()
    {
        if (InputSystem.actions["Jump"].WasPressedThisFrame())
        {
            animator.SetTrigger("Jump");
        }
    }
}
