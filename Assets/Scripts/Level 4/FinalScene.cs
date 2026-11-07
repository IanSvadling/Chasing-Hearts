using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    [SerializeField] private string webGLExitScene = "TitleScreen";
    [SerializeField] private InputAction enterPress;
    [SerializeField] private GameObject[] panels;
    private int currentPanel = 0;

    private void OnEnable()
    {
        enterPress.Enable();
    }
    private void OnDisable()
    {
        enterPress.Disable();
    }

    private void Update()
    {
        if(currentPanel == 3)
        {
            enterPress.Disable();
        }
        if (enterPress.triggered)
        {
            int currentPanel = UpdateCurrentPanel();
            panels[currentPanel].SetActive(true);
        }
    }

    private int UpdateCurrentPanel()
    {
        currentPanel++;
        return currentPanel;
    }

    public void OnClickExitGame()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if(!string.IsNullOrEmpty(webGLExitScene)){
            SceneManager.LoadScene(webGLExitScene);
        } else{
            Debug.Log("WebGL Build not supported");
        }
#elif UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
