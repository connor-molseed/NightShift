using UltEvents;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    //Config Parameters
    [SerializeField] private bool _printDebugMessages = true;
    [SerializeField] protected string _displayName = "Name";

    
    //State Variables
    [SerializeField] protected bool _enabled = true;
    
    //Cached References
    
    //Properties
    public bool IsEnabled 
    { 
        get { return _enabled; }
        set { _enabled = value; }
    }

    public string DisplayName => _displayName;
    
    //Events
    public UltEvent<InteractionContext> InteractPressed;
    public UltEvent<InteractionContext> InteractHeld;

    public void Interact(InteractionContext context)
    {
        if (_printDebugMessages) Debug.Log($"{name} was interacted with.");

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