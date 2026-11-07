using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [Header("Panel references")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject audioPanel;
    [SerializeField] private GameObject controlsPanel;

    [Header("Title Screen References")]
    [SerializeField] private string webGLExitScene = "TitleScreen";
    [SerializeField] private string startScene = "GameViewLevel1";
    [SerializeField] private InGameOrTitleProfile profile;

    [SerializeField] private InputAction escPress;
    private MenuNavigator navigator = new MenuNavigator();
    private bool isPaused;
    private string quitScreen = "TitleScreen";
    [SerializeField] private MovementProfile moveMode;

    #region Processing
    private void Awake()
    {
        if(profile.mode == InGameOrTitle.TitleScreen)
        {
            mainPanel.SetActive(true);
            settingsPanel.SetActive(false);
            audioPanel.SetActive(false);
            controlsPanel.SetActive(false);
        }
        else 
        {
            mainPanel.SetActive(false);
            settingsPanel.SetActive(false);
            audioPanel.SetActive(false);
            controlsPanel.SetActive(false);
        }  
    }

    private void OnEnable()
    {
        escPress.Enable();
    }

    private void OnDisable()
    {
        escPress.Disable();
    }

    private void Start()
    {
        Debug.Log($"Pause menu mode: {profile.mode}");
        if (profile.mode == InGameOrTitle.TitleScreen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(moveMode.mode == MovementMode.Full3D)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        if(profile.mode == InGameOrTitle.TitleScreen)
        {
            return;
        }

        if (!escPress.triggered)
        {
            return;
        }

        if (!isPaused)
        {
            navigator.OpenMenu(MenuType.Main);
            RefreshPanels();

            PauseTime();
            isPaused = true;
        }
        else
        {
            HideAllPanels();

            StartTime();
            isPaused = false;
        }
    }

    public void HideAllPanels()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        audioPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }
    #endregion

    #region Panel Buttons
    public void OpenSettings()
    {
        Debug.Log("button was clicked");
        navigator.OpenMenu(MenuType.Settings);
        RefreshPanels();
    }

    public void OpenAudio()
    {
        navigator.OpenMenu(MenuType.Audio);
        RefreshPanels();
    }

    public void OpenControls()
    {
        navigator.OpenMenu(MenuType.Controls);
        RefreshPanels();
    }

    public void Back()
    {
        navigator.GoBack();
        RefreshPanels();
    }

    private void RefreshPanels()
    {
        mainPanel.SetActive(navigator.CurrentMenu == MenuType.Main);
        settingsPanel.SetActive(navigator.CurrentMenu == MenuType.Settings);
        audioPanel.SetActive(navigator.CurrentMenu == MenuType.Audio);
        controlsPanel.SetActive(navigator.CurrentMenu == MenuType.Controls);
    }
    #endregion

    #region Time
    private void PauseTime()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       
        Time.timeScale = 0f;
    }

    private void StartTime()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        Time.timeScale = 1f;
    }
    #endregion

    public void OnClickQuit()
    {
        SceneManager.LoadScene(quitScreen);
        Time.timeScale = 1f;
    }
}
