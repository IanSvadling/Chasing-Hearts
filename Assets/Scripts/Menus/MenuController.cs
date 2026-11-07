using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string webGLExitScene = "TitleScreen";
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private InGameOrTitleProfile profile;

    private void Start()
    {
        if(profile.mode == InGameOrTitle.TitleScreen)
        {
            instructionsPanel.SetActive(false);
            menuPanel.SetActive(true);
        }       
    }

    public void OnClickExit()
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

    public void OnClickStart()
    {
        instructionsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
}
