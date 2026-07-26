using UnityEngine;

public class CarryController : MonoBehaviour
{
    //Config Parameters
    [SerializeField] protected Transform _itemAttachPoint;
    
    //State Variables
    protected Carryable _heldItem;
    
    //Cached References
    
    //Properties
    
    //Events
    


    public bool PickupObject(Carryable obj)
    {
        if (obj == null) return false;

        if (_heldItem != null)
        {
            Debug.Log($"Already holding {_heldItem.name}, and cannot carry anymore");
            return false;
        }

        _heldItem = obj;
        _heldItem.transform.SetParent(_itemAttachPoint);
        _heldItem.transform.localPosition = Vector3.zero;
        _heldItem.transform.localRotation = _itemAttachPoint.localRotation;
        _heldItem.gameObject.layer = LayerMask.NameToLayer("Player");

        Debug.Log($"Now carrying {_heldItem.name}");
        
        return true;
    }

    public bool DropObject(Vector3 location)
    {
        if (_heldItem == null) return false;

        _heldItem.transform.SetParent(null);
        _heldItem.transform.position = location;
        _heldItem.gameObject.layer = _heldItem.OriginalLayer;

        Debug.Log($"{_heldItem.name} has been put down again");
        _heldItem = null;

        return true;
    }
}