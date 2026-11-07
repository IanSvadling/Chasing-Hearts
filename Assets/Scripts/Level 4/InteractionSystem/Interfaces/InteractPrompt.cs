using TMPro;
using UnityEngine;

public class InteractPrompt : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private Vector3 offset = new(0f, 1f, 0f);
    
    private Camera cam;
    private Transform target;
    private Canvas canvas;
    private RectTransform canvasRect;
    private RectTransform labelRect;

    private void Awake()
    {
        cam = Camera.main;
        labelRect = label.rectTransform;
        canvas = label.GetComponentInParent<Canvas>();
        canvasRect = canvas.GetComponent<RectTransform>();
        Hide();
    }

    private void LateUpdate()
    {
        if(target == null) { return; }

        if (!label.gameObject.activeSelf)
        {
            label.gameObject.SetActive(true);
        }
        Vector3 worldPos = target.position + offset;
        Vector3 screenPos = cam.WorldToScreenPoint(worldPos);
        Camera uiCam = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : cam; 
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, uiCam, out Vector2 localPoint))
        {
            labelRect.anchoredPosition = localPoint;
        }
    }

    public void Hide()
    {
        label.gameObject.SetActive(false);
        target = null;
    }

    public void Show(IInteractable interactable)
    {
        if(interactable == null)
        {
            Hide();
            return;
        }
        target = interactable.transform;
        label.text = $"[E] {interactable.DisplayText}";
        label.gameObject.SetActive(true);
    }
}
