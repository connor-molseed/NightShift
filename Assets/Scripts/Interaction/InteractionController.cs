using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InteractionController : MonoBehaviour
{
    [SerializeField] protected InputActionReference _interactButton;

    //Duplicates behaviour in PickupObject.cs, may need to split into shared class??
    [SerializeField] protected float _maxDistance = 20f;
    [SerializeField] protected LayerMask _ignoredLayers;
    protected IInteractable _target;
    protected Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void OnEnable()
    {
        Debug.Log("Doing an enable");
        _interactButton.action.Enable();
        _interactButton.action.performed += OnInteractPressed;
    }

    void OnDisable()
    {
        Debug.Log("Doing a disable");
        _interactButton.action.performed -= OnInteractPressed;
    }

    void Update()
    {
        UpdateCurrentTarget();
    }

    void UpdateCurrentTarget()
    {
        if (!_camera) return;

        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _maxDistance, ~_ignoredLayers))
        {
            IInteractable target = hit.collider.attachedRigidbody?.GetComponent<IInteractable>();
            if (target != null)
            {
                _target = target;
            }
            else
            {
                _target = null;
            }
        }
    }
    
    void OnInteractPressed(InputAction.CallbackContext context)
    {
        if (context.interaction is HoldInteraction)
            TryDoInteract(InputType.Hold);
        else if (context.interaction is PressInteraction)
            TryDoInteract(InputType.Press);
    }

    bool TryDoInteract(InputType inputType)
    {
        if (_target != null)
        {
            InteractContext context = new InteractContext(gameObject, inputType);
            _target.Interact(context);
            return true;
        }
        return false;
    }
}