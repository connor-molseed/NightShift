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
    public UltEvent<InteractionContext> InteractPressed;
    public UltEvent<InteractionContext> InteractHeld;

    public void Interact(InteractionContext context)
    {
        Debug.Log($"{name} was interacted with.");
        if (context.Type == InputType.Press)
        {
            InteractPressed.Invoke(context);
        }
        else if (context.Type == InputType.Hold)
        {
            InteractHeld.Invoke(context);
        }
    }
}