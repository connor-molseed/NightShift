using UnityEngine;
using UnityEngine.InputSystem;

using Core.Items;

public class CarryController : MonoBehaviour
{
    //Config Parameters
    [SerializeField] protected Transform _itemAttachPoint;
    [SerializeField] protected InputActionReference _dropButton;
    [SerializeField] protected float _dropDistance;
    
    //State Variables
    protected Carryable _heldItem;

    //Cached References
    protected Inventory _inventory;

    //Properties
    public Carryable CarriedItem => _heldItem;

    //Events


    void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }

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

        AttachCarryable(obj);

        _inventory.AddItem(_heldItem.ItemData);
        
        return true;
    }

    public bool TryDropObject(Vector3 location)
    {
        if (_heldItem == null) return false;

        Carryable obj = DetatchCarryable();

        obj.transform.position = location;
        _inventory.RemoveItem(obj.ItemData);

        return true;
    }

    public Carryable RemoveCarriedItem()
    {
        Carryable obj = DetatchCarryable();
        _inventory.RemoveItem(obj.ItemData);

        return obj;
    }

    protected void AttachCarryable(Carryable obj)
    {
        _heldItem = obj;
        _heldItem.transform.SetParent(_itemAttachPoint);
        _heldItem.transform.localPosition = Vector3.zero;
        _heldItem.transform.localRotation = _itemAttachPoint.localRotation;
        _heldItem.gameObject.layer = LayerMask.NameToLayer("Player");
        _heldItem.EnablePhysics(false);

        Debug.Log($"Now carrying {_heldItem.name}");
    }

    protected Carryable DetatchCarryable()
    {
        Carryable obj = _heldItem;
        
        _heldItem.transform.SetParent(null);
        _heldItem.gameObject.layer = _heldItem.OriginalLayer;
        _heldItem.EnablePhysics(true);
        _heldItem = null;

        Debug.Log($"{obj.name} has been put down again");

        return obj;
    }

    protected Vector3 GetDropLocation()
    {
        return _itemAttachPoint.transform.position;
    }
}