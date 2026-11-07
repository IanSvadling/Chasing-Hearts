using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InsideTransitionScene : MonoBehaviour
{
    [SerializeField] private string nextScene;
    [SerializeField] private InputAction enterPress;

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
        if (enterPress.triggered)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
