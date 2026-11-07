using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
   [Header("References")]
   [SerializeField] private Transform player;
   [SerializeField] private Transform orientation;
   [SerializeField] private Transform playerObj;

   [Header("Settings")]
   [SerializeField] private float rotationSpeed;

    //private void Start()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}

    public void Update()
    {
        // rotate orientation based on camera position
        Vector3 viewDirection = player.position - new Vector3(
            transform.position.x, 
            player.position.y, 
            transform.position.z
            );

        orientation.forward = viewDirection.normalized;
    }

    public void RotatePlayer(Vector3 moveDirection)
    {
        if(moveDirection == Vector3.zero) { return; }

        playerObj.forward = Vector3.Slerp(
                playerObj.forward, 
                moveDirection.normalized, 
                Time.deltaTime * rotationSpeed
        );
    }
}
