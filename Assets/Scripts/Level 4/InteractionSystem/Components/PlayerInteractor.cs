using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float radius = 5f;
    [SerializeField] private LayerMask interactableLayers;
    [SerializeField] private InputAction eKey;
    [SerializeField] private InteractPrompt prompt;

    private Collider[] buffer = new Collider[6];
    private IInteractable focused;

    private void Update()
    {
        IInteractable nearest = FindNearestInteractable();
        UpdateFocus(nearest);

        if(focused != null && eKey.triggered)
        {
            if (focused.CanInteract())
            {
                focused.Interact();
            }
        }
    }

    private void OnEnable()
    {
        eKey.Enable();
    }

    private void OnDisable()
    {
        eKey.Disable();
    }

    private IInteractable FindNearestInteractable()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position, radius, buffer, interactableLayers, QueryTriggerInteraction.Collide);
        IInteractable nearest = null;
        float bestDistanceSq = float.MaxValue;

        for(int i = 0; i < count; i++)
        {
            Collider col = buffer[i];

            if(col == null) continue;

            IInteractable interactable = col.GetComponentInParent<IInteractable>();

            if(interactable == null) continue;
            if(!interactable.CanInteract()) continue;

            float distanceSq = (col.transform.position - transform.position).sqrMagnitude;

            if(distanceSq < bestDistanceSq)
            {
                bestDistanceSq = distanceSq;
                nearest = interactable;
            }
        }

        return nearest;
    }

    private void UpdateFocus(IInteractable nearest)
    {
        if(ReferenceEquals(focused, nearest)) return;
        focused?.OnFocusLost();
        focused = nearest;

        if(focused != null)
        {
            focused.OnFocusGained();
            prompt.Show(focused);
        }
        else
        {
            prompt.Hide();
        }
    }
}
