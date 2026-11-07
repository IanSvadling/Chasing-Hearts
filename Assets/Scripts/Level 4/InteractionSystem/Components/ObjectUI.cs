using UnityEngine;

public class ObjectUI : MonoBehaviour
{
    [Header("Panel references")]
    [SerializeField] private GameObject signPanel;
    [SerializeField] private GameObject picturePanel;
    [SerializeField] private GameObject hatPanel;
    [SerializeField] private GameObject tablePanel;

    [Header("Interactable object references")]
    [SerializeField] private GameObject sign;
    [SerializeField] private GameObject picture;
    [SerializeField] private GameObject hat;
    [SerializeField] private GameObject table;

    [Header("Secret Hedge Door")]
    [SerializeField] private GameObject secretHedgeDoor;
    [SerializeField] private Transform endPos;
    [SerializeField] private GameObject heart;
    private float speed = 3.0f;
    private bool doorIsMoving;
    private Interactable interactable;

    private bool signActive = false;
    private bool pictureActive = false;
    private bool hatActive = false;
    private bool tableActive = false;

    private void Awake()
    {
        heart.SetActive(false);
    }

    private void Update()
    {
        MoveSecretDoor(); // has to be in Update so it moves not just once for one frame
    }

    public void ToggleSignPanel()
    {
        signActive = !signActive;
        signPanel.SetActive(signActive);
        picture.GetComponent<Interactable>().SetInteractionEnabled(true);
    }

    public void TogglePicturePanel()
    {
        pictureActive = !pictureActive;
        picturePanel.SetActive(pictureActive);
        hat.GetComponent<Interactable>().SetInteractionEnabled(true);
    }

    public void ToggleHatPanel()
    {
        hatActive = !hatActive;
        hatPanel.SetActive(hatActive);
        table.GetComponent<Interactable>().SetInteractionEnabled(true);
    }

    public void ToggleTablePanel()
    {
        tableActive = !tableActive;
        tablePanel.SetActive(tableActive);
    }

    public void OpenOnStatueInteract()
    {
        doorIsMoving = true;
        MoveSecretDoor();
        heart.SetActive(true);

    }

    private void MoveSecretDoor()
    {
        if (!doorIsMoving)
        {
            return;
        }

        secretHedgeDoor.transform.position = Vector3.MoveTowards(
            secretHedgeDoor.transform.position, 
            endPos.position, 
            speed * Time.deltaTime
        );

        if(Vector3.Distance(secretHedgeDoor.transform.position, endPos.position) < 0.01f)
        {
            secretHedgeDoor.transform.position = endPos.position;
            doorIsMoving = false;
            Debug.Log("Door moved");
        }
    }
}
