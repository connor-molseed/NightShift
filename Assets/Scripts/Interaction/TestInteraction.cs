using UnityEngine;

//TODO technically a project issue not this script -> change variable syntax to standard?
public class TestInteraction : MonoBehaviour, IInteractable
{
    public void Interact(InteractContext context)
    {
        if (context._inputType == InputType.Press)
            OnInteractPress();
        else if (context._inputType == InputType.Hold)
            OnInteractHold();
    }

    protected void OnInteractPress()
    {
        Debug.Log("This was only a press");
    }

    protected void OnInteractHold()
    {
        Debug.Log("This was a full hold!");
    }
}