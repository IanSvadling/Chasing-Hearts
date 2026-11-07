using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartCollecting : MonoBehaviour
{
    public static HeartCollecting Instance { get; private set; }
    
    [Header("Scene names")]
    [SerializeField] private string TransitionScene1;
    [SerializeField] private string Level2;
    [SerializeField] private string TransitionScene2;
    [SerializeField] private string Level3;
    [SerializeField] private string TransitionLevel3;
    [SerializeField] private string Level4;

    [Header("Heart progress")]
    [SerializeField] public int heartCounter; 

    public int HeartCounter => heartCounter;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void CheckForSceneChange()
    {
        string nextScene = null;

        if(heartCounter == 3)
        {
            nextScene = TransitionScene1;
        }
        else if(heartCounter == 7)
        {
            nextScene = TransitionScene2;
        } 
        else if(heartCounter == 12)
        {
            nextScene = TransitionLevel3;
        }

        if (!string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void CollectHeart()
    {
        heartCounter++;
        CheckForSceneChange();
        Debug.Log("Number of hearts collected: " + heartCounter);
    }

    public void ResetHearts()
    {
        heartCounter = 0;
    }
}
