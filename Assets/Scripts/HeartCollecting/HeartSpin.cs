using UnityEngine;

public class HeartSpin : MonoBehaviour
{
    [SerializeField] private GameObject heart;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;

    private float rotateSpeed = 100.0f;
    private float floatingSpeed = 0.5f;
    private bool floatingUp = true;

    private void Start()
    {
        heart.transform.position = startPos.position;
    }

    private void Update()
    {
        heart.transform.Rotate(0f, 1f * rotateSpeed * Time.deltaTime, 0f);
        Float();
    }

    private void Float()
    {
        Vector3 targetPosition = floatingUp ? endPos.position : startPos.position;

        heart.transform.position = Vector3.MoveTowards(
            heart.transform.position, 
            targetPosition, 
            floatingSpeed * Time.deltaTime
        );
        
        if(Vector3.Distance(heart.transform.position, targetPosition) < 0.01f)
        {
            floatingUp = !floatingUp;
        }
    }
}
