using UnityEngine;
using UnityEngine.InputSystem;

public class CarryController : MonoBehaviour
{
    //Config Parameters
    [SerializeField] protected Transform _itemAttachPoint;
    [SerializeField] protected InputActionReference _dropButton;
    [SerializeField] protected float _dropDistance;
    
    //State Variables
    protected Carryable _heldItem;

    //Cached References

    //Properties

    //Events
    void OnEnable()
    {
        Debug.Log("Doing an enable");
        _dropButton.action.Enable();
        _dropButton.action.performed += HandleDropInput;
    }

    void OnDisable()
    {
        Debug.Log("Doing a disable");
        _dropButton.action.performed -= HandleDropInput;
    }

    public Carryable GetCurrentObject()
    {
        return _heldItem;
    }

    public void HandleDropInput(InputAction.CallbackContext context)
    {  
        if (_heldItem == null) return;

        TryDropObject(GetDropLocation());
    }

    public bool TryPickupObject(Carryable obj)
    {
        if (obj == null) return false;

        if (_heldItem != null)
        {
            if (!TryDropObject(obj.transform.position))
            {
                Debug.Log($"Already holding {_heldItem.name}, and cannot currently drop it");
                return false;
            }
            Debug.Log($"Already had an item, but swapped it with the new one");
        }

        _heldItem = obj;
        _heldItem.transform.SetParent(_itemAttachPoint);
        _heldItem.transform.localPosition = Vector3.zero;
        _heldItem.transform.localRotation = _itemAttachPoint.localRotation;
        _heldItem.gameObject.layer = LayerMask.NameToLayer("Player");
        _heldItem.EnablePhysics(false);

        Debug.Log($"Now carrying {_heldItem.name}");
        
        return true;
    }

    public bool TryDropObject(Vector3 location)
    {
        if (_heldItem == null) return false;

        _heldItem.transform.SetParent(null);
        _heldItem.transform.position = location;
        _heldItem.gameObject.layer = _heldItem.OriginalLayer;
        _heldItem.EnablePhysics(true);

        Debug.Log($"{_heldItem.name} has been put down again");
        _heldItem = null;

        return true;
    }

    protected Vector3 GetDropLocation()
    {
        return _itemAttachPoint.transform.position;
    }
}