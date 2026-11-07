using UnityEngine;

public interface IInteractable
{
    Transform transform { get; }

    string DisplayText { get; }

    bool CanInteract();

    void Interact();

    void OnFocusGained();

    void OnFocusLost();
}
