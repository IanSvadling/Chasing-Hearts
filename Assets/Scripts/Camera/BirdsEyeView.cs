using UnityEngine;
using UnityEngine.InputSystem;

public class BirdsEyeView : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] private GameObject thirdPersonCam;
    [SerializeField] private GameObject birdsEyeViewCam;

    [Header("Input Actions")]
    [SerializeField] private InputAction enterBirdsView;
    [SerializeField] private InputAction exitBirdsView;

    private bool birdEnabled;

    private void Awake()
    {
        DisableBirdsEyeView();
    }

    private void OnEnable()
    {
        enterBirdsView.Enable();
        exitBirdsView.Enable();
    }

    private void OnDisable()
    {
        enterBirdsView.Disable();
        exitBirdsView.Disable();
    }

    private void EnableBirdsEyeView()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        thirdPersonCam.SetActive(false);

        birdsEyeViewCam.SetActive(true);
        birdEnabled = true;
    }

    private void DisableBirdsEyeView()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        thirdPersonCam.SetActive(true);

        birdsEyeViewCam.SetActive(false);
        birdEnabled = false;
    }

    private void Update()
    {
        if(enterBirdsView.triggered && !birdEnabled)
        {
            EnableBirdsEyeView();
        } 
        else if(exitBirdsView.triggered && birdEnabled)
        {
            DisableBirdsEyeView();
        }
    }
}
