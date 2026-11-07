using UnityEngine;
using UnityEngine.UI;

public class ObstacleCollision : MonoBehaviour
{
   private LifeController lc;

   void Start()
    {
        lc = FindFirstObjectByType<LifeController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lc.LoseLife();
        }
    }
}
