using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public Image[] lives;
  
    private int lifeIndex = 2;
    [SerializeField] private string reloadScene;
    private HeartCollecting heartCollecting;

    public void LoseLife()
    {
        if(lifeIndex < lives.Length && lifeIndex >= 0)
        {
            lives[lifeIndex].enabled = false;
            lifeIndex--;
        } 
        if(lifeIndex < 0)
        {
            SceneManager.LoadScene(reloadScene);
            lifeIndex = 2;
            heartCollecting.ResetHearts();
            Debug.Log("heart counter: " + heartCollecting.heartCounter);
        }

    }

    public void GainLife()
    {
        if(lifeIndex < lives.Length - 1 && lifeIndex >= 0)
        {
            lifeIndex++;
            lives[lifeIndex].enabled = true;
        } 
    }
}
