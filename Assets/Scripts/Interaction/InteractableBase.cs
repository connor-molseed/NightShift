using UnityEngine;

//TODO technically a project issue not this script -> change variable syntax to standard?
/**
//TODO Should interactableBase be a seperate component with events that others hook into?? 
    May want UI to sync with interact elements, but they'll get buried in complex interactables
    Helps seperate the logic of Interactable and the logic of an items specific behaviour
**/
public class InteractableBase : MonoBehaviour, IInteractable
{
    public void Interact(InteractContext context)
    {
        if (context._inputType == InputType.Press)
            OnInteractPress(context._user);
        else if (context._inputType == InputType.Hold)
            OnInteractHold(context._user);
    }

    protected virtual void OnInteractPress(GameObject user)
    {
        Debug.Log("This was only a press, but no behaviour is defined");
    }

    protected virtual void OnInteractHold(GameObject user)
    {
        Debug.Log("This was a full hold! But not behaviour was defined");
    }
}