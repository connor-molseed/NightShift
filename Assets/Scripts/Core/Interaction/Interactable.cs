using UltEvents;
using UnityEngine;

namespace Core.Interaction
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        //Config Parameters
        [SerializeField] private bool _printDebugMessages = true;
        [SerializeField] protected string _displayName = "Name";
    
        
        //State Variables
        [SerializeField] protected bool _enabled = true;
        
        //Cached References
        
        //Properties
        public bool IsInteractable 
        { 
            get { return _enabled; }
            set { _enabled = value; }
        }
    
        public string DisplayName => _displayName;
        
        //Events
        public UltEvent<InteractionContext> OnInteractPressed;
        public UltEvent<InteractionContext> OnInteractHeld;

        public bool InteractPress(InteractionContext context)
        {
            if (_printDebugMessages) Debug.Log($"{name} was interacted with.");
            OnInteractPressed.Invoke(context);
            return true;
        }

        public bool InteractHold(InteractionContext context)
        {
            if (_printDebugMessages) Debug.Log($"{name} was interacted with.");

            OnInteractHeld.Invoke(context);
            return true;
        }
    }
}