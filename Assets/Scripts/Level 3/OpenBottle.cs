using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenBottle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject cork;
    [SerializeField] private TMP_Text eText;
    [SerializeField] private Transform player;

    [Header("Input Actions")]
    [SerializeField] private InputAction ePress;

    [Header("Proximity Detection")]
    private Transform target;
    private float proximityRadius = 5.0f;

    [Header("Heart Movement")]
    private float speed = 5.0f;
    [SerializeField] private Transform finalPos;
    private bool heartIsMoving;
    private bool bottleOpened;

    private void Awake()
    {
        eText.enabled = false; 
        heart.SetActive(false);
    }

    private void Start()
    {
        target = cork.transform;
    }

    private void OnEnable()
    {
        ePress.Enable();
    }

    private void OnDisable()
    {
        ePress.Disable();
    }

    private void Update()
    {
        CheckForInteraction();
        MoveHeart();
    }

    private void CheckForInteraction()
    {
        if(target == null || bottleOpened)
        {
            eText.enabled = false;
            return;
        }

        // calculate distance
        float distance = Vector3.Distance(player.position, target.position);

        if(distance <= proximityRadius)
        {
            eText.enabled = true;

            if (ePress.triggered)
            {
                OpenTheBottle();
                Debug.Log("E was pressed");
            }
        }
        else
        {
            eText.enabled = false;
        }
    }

    private void OpenTheBottle()
    {
        bottleOpened = true;
        eText.enabled = false;

        cork.SetActive(false);
        heart.SetActive(true);

        heartIsMoving = true;
        Debug.Log("Bottle opened");
    }

    private void MoveHeart()
    {
        if (!heartIsMoving)
        {
            return;
        }
        Debug.Log("Time scale: " + Time.timeScale);
        heart.transform.position = Vector3.MoveTowards(
            heart.transform.position, 
            finalPos.position, 
            speed * Time.deltaTime
        );
        Debug.Log("heart moved");

        if(Vector3.Distance(heart.transform.position, finalPos.position) < 0.01f)
        {
            heart.transform.position = finalPos.position;
            heartIsMoving = false;
        }
    }
}
