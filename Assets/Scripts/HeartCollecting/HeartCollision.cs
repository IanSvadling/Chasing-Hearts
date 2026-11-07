using UnityEngine;

public class HeartCollision : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player hit: " + gameObject);
            HeartCollecting.Instance.CollectHeart();
            Destroy(gameObject);
        } else
        {
            return;
        }
    }
}
