using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel1 : MonoBehaviour
{
    [SerializeField] private string firstLevel = "GameViewLevel1";

    public void OnClickContinue()
    {
        if (firstLevel != null)
        {
            SceneManager.LoadScene(firstLevel);
            Time.timeScale = 1f;
        }
    }
}
