using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public float lowerBound = -25.0f;
    void Update()
    {
        if(transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
