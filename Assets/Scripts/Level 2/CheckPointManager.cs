using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager Instance;

    [SerializeField] private Transform player;
    [SerializeField] private Transform defaultSpawnPoint;

    private Vector3 currentSpawnPoint;

    private void Awake()
    {
        Instance = this;

        if(defaultSpawnPoint != null)
        {
            currentSpawnPoint = defaultSpawnPoint.position;
        }

        if(player != null)
        {
            currentSpawnPoint = player.position;
        }
    }

    public void SetCheckpoint(Vector3 newSpawnPoint)
    {
        currentSpawnPoint = newSpawnPoint;
        Debug.Log("Checkpoint set to: " + currentSpawnPoint);
    }

    public void RespawnPlayer()
    {
        player.position = currentSpawnPoint;

        Rigidbody rb = player.GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
