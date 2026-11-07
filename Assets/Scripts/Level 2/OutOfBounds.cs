using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverPanel;

    private float yBound = -1.0f;

    void Awake()
    {
        if(gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Vector3 currentPos = player.transform.position; 

        if(currentPos.y <= yBound){
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void OnClickContinue()
    {
        gameOverPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1.0f;
        CheckPointManager.Instance.RespawnPlayer();
    }
}
