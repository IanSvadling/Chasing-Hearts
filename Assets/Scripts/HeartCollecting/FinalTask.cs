using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FinalTask : MonoBehaviour
{
    [Header("Queens Door")]
    [SerializeField] private GameObject queensDoor;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject finalMessagePanel;
    [SerializeField] private InputAction yPress;
    [SerializeField] private string finalScene;
    [SerializeField] private GameObject headToText;
    private float doorRadius = 5.0f;

    private void Awake()
    {
        headToText.SetActive(false);
    }

    private void Update()
    {
        OpenQueensDoor();
    }

    private void OnEnable()
    {
        yPress.Enable();
    }

    private void OnDisable()
    {
        yPress.Disable();
    }

    private void OpenQueensDoor()
    {
        if(HeartCollecting.Instance.heartCounter == 13)
        {
            headToText.SetActive(true);
            // calculate player distance from door
            if(Vector3.Distance(player.transform.position, queensDoor.transform.position) <= doorRadius)
            {
                Debug.Log("Player in range");
                finalMessagePanel.SetActive(true);
                if (yPress.triggered)
                {
                    SceneManager.LoadScene(finalScene);
                }
            } else
            {
                finalMessagePanel.SetActive(false);
            }
        }
    }
}