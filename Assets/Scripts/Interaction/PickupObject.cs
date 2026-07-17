using UnityEngine;
using UnityEngine.InputSystem;

public class PickupObject : MonoBehaviour
{
    //Config Parameters
    [SerializeField] protected float _maxDistance = 20f;
    [SerializeField] protected LayerMask _ignoredLayers;
    [SerializeField] protected InputActionReference _interactButton;
    [SerializeField] protected Transform _itemAttachPoint;
    
    //State Variables
    protected GameObject _targetItem;
    protected GameObject _heldItem;
    
    //Cached References
    protected Camera _camera;
    
    //Properties
    
    //Events
    
    void Start()
    {
        _camera = Camera.main;
    }

    void OnEnable()
    {
        Debug.Log("Doing an enable");
        _interactButton.action.Enable();
        _interactButton.action.canceled += PickupItem;
    }

    void OnDisable()
    {
        Debug.Log("Doing a disable");
        _interactButton.action.canceled -= PickupItem;
    }

    // Update is called once per frame
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
            //TODO Likely change to generic interactable interface in future
            Carryable target = hit.collider.GetComponent<Carryable>();
            if (target != null)
            {
                _targetItem = target.gameObject;
            }
            else
            {
                _targetItem = null;
            }
        }
    }

    public void PickupItem(InputAction.CallbackContext context)
    {
        Debug.Log("Interact Callback was called");
        if (_targetItem != null)
        {
            if (_heldItem != null)
            {
                Debug.Log($"Already holding {_heldItem.name}, and cannot carry anymore");
                return;
            }
            //TODO Move this over to the carried object maybe?
            _heldItem = _targetItem;
            _heldItem.transform.SetParent(_itemAttachPoint);
            _heldItem.transform.localPosition = Vector3.zero;
            _heldItem.transform.localRotation = _itemAttachPoint.localRotation;
            _heldItem.layer = LayerMask.NameToLayer("Player");
            
            Debug.Log($"Now carrying {_heldItem.name}");
        }
        else if (_heldItem != null)
        {
            Debug.Log("Not looking at anything");
            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _maxDistance, ~_ignoredLayers))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (Vector3.Dot(hit.normal, Vector3.up) > 0.9f)
                {
                    PutItemDown(hit.point);
                }
            }
        }
    }

    protected void PutItemDown(Vector3 location)
    {
        _heldItem.transform.SetParent(null);
        _heldItem.transform.position = location;
        _heldItem.layer = LayerMask.NameToLayer("Default"); //TODO Need better option than just assuming it was on default layer

        Debug.Log($"{_heldItem.name} has been put down again");
        _heldItem = null;
    }

}
