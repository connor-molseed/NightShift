using UnityEngine;
using UnityEngine.InputSystem;

using Core.Items;

public class CarryController : MonoBehaviour
{
    //Config Parameters
    [SerializeField] protected InputActionReference _grabInput;

    [SerializeField] protected Transform _itemAttachPoint;
    [SerializeField] protected float _dropDistance;
    
    //State Variables
    protected Carryable _heldItem;

    //Cached References
    private TargetFinder _target;

    //Properties
    public Carryable CarriedItem => _heldItem;
    public bool IsCarryingItem => _heldItem != null;

    //Events


    void Awake()
    {
        
    }

    void OnEnable()
    {
        Debug.Log("Doing an enable");
        _grabInput.action.Enable();
        _grabInput.action.performed += HandleInput;
    }

    void OnDisable()
    {
        Debug.Log("Doing a disable");
        _grabInput.action.performed -= HandleInput;
    }

    // public Carryable GetCurrentObject()
    // {
    //     return _heldItem;
    // }

    public void HandleInput(InputAction.CallbackContext context)
    {  
        Carryable carryable = _target.GetComponent<Carryable>();
        if (carryable == null) return;

        if (IsCarryingItem)
        {
            TryDropObject();
        }
        else
        {
            TryPickupObject(carryable);
        }
    }

    public bool TryPickupObject(Carryable obj)
    {
        if (obj == null) return false;

        if (_heldItem != null)
        {
            if (!TryDropObject())
            {
                Debug.Log($"Already holding {_heldItem.ItemData.name}, and cannot currently drop it");
                return false;
            }
            Debug.Log($"Already had an item, but swapped it with the new one");
        }

        AttachCarryable(obj);
        
        return true;
    }

    public bool TryDropObject()
    {
        if (_heldItem == null) return false;

        Carryable obj = DetatchCarryable();

        obj.transform.position = GetDropLocation();

        return true;
    }

    public Carryable RemoveCarriedItem()
    {
        Carryable obj = DetatchCarryable();

        return obj;
    }

    protected void AttachCarryable(Carryable obj)
    {
        _heldItem = obj;
        _heldItem.Root.SetParent(_itemAttachPoint);
        _heldItem.Root.localPosition = Vector3.zero;
        _heldItem.Root.localRotation = _itemAttachPoint.localRotation;
        _heldItem.Root.gameObject.layer = LayerMask.NameToLayer("Player");
        _heldItem.EnablePhysics(false);

        Debug.Log($"Now carrying {_heldItem.ItemData.name}");
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