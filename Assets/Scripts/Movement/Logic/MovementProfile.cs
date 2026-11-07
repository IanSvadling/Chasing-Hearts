using UnityEngine;

[CreateAssetMenu(menuName = "Player/Movement profile")]
public class MovementProfile : ScriptableObject
{
   [Header("Movement")]
   public MovementMode mode;
   public float moveSpeed;
   public float groundDrag;
   public float airMultiplier;

   [Header("Direction")]
   public bool useOrientation;

   [Header("Jumping")]
   public bool canJump;
   public float jumpForce;
   public float jumpCoolDown;
}
