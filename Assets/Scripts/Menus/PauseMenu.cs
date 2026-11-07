using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private MovementProfile profile;

    private string quitScreen = "TitleScreen";
    private bool isPaused = false;

    [SerializeField] private InputAction escPress; 
    
    void Start()
    {
        escPress.Enable();
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (escPress.triggered)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // pause game with Time.timescale
    void PauseGame()
    {
        if(profile.mode == MovementMode.Full3D)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        if(profile.mode == MovementMode.Full3D)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void OnClickQuit()
    {
        SceneManager.LoadScene(quitScreen);
        Time.timeScale = 1f;
    }

    public void OnClickResume()
    {
        ResumeGame();
    }
}
