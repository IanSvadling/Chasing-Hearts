using UnityEngine;

public class LifeUpCollision : MonoBehaviour
{
    LifeController lc;
    

    void Start()
    {
        lc = FindFirstObjectByType<LifeController>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lc.GainLife();
            Destroy(gameObject);
        }
    }
}
