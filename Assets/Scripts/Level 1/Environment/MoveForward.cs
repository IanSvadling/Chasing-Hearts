using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10.0f;
    
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
