using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    private bool collected;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player hit rose");
        if(collected) { return; }

        if (other.CompareTag("Player"))
        {
            collected = true;

            if(spawnPoint != null)
            {
                CheckPointManager.Instance.SetCheckpoint(spawnPoint.position);
            }
            
        }    
    }
}
