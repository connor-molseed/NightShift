using UltEvents;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    //Config Parameters
    [SerializeField] private bool _printDebugMessages = true;
    
    //State Variables
    
    //Cached References
    
    //Properties
    
    //Events
    public UltEvent<GameObject> InteractPressed;
    public UltEvent<GameObject> InteractHeld;

    public void Interact(InteractionContext context)
    {
        Debug.Log($"{name} was interacted with.");
        if (context._inputType == InputType.Press)
            InteractPressed.Invoke(context._user);
        else if (context._inputType == InputType.Hold)
            InteractHeld.Invoke(context._user);
    }
}