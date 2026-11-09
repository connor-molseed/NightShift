using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

using Core.Interaction;

namespace Core.Control
{
    public class InteractController : MonoBehaviour
    {
        [SerializeField] protected InputActionReference _interactInput;
        //Config Parameters
        
        //State Variables
        private TargetFinder _targetFinder;
        private CarryController _grabHandler;

        //Cached References

        //Properties

        //Events

        void Awake()
        {
            _targetFinder = GetComponent<TargetFinder>();
            _grabHandler = GetComponent<CarryController>();
        }

        void OnEnable()
        {
            Debug.Log("Doing an enable");
            _interactInput.action.Enable();
            _interactInput.action.performed += HandleInput;
        }
    
        void OnDisable()
        {
            Debug.Log("Doing a disable");
            _interactInput.action.performed -= HandleInput;
        }
        
        void HandleInput(InputAction.CallbackContext context)
        {
            IInteractable interactable = _targetFinder.Target.GetComponent<IInteractable>();
            Debug.Log($"Target is {_targetFinder.Target}");


            if (interactable == null) return;

            InteractionContext interactContext = new InteractionContext(gameObject);

            if (context.interaction is HoldInteraction)
            {
                interactable.InteractHold(interactContext);
            }
            else if (context.interaction is PressInteraction)
            {
                interactable.InteractPress(interactContext);
            }
        }
    }
}