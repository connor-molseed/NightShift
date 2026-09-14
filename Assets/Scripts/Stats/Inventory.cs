using UltEvents;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Config Parameters
    
    //State Variables
    [SerializeField] protected bool _hasKey = true;
    [SerializeField] protected bool _hasCutter = true;
    [SerializeField] protected CarriedItemData _carriedItem;
    
    //Cached References

    
    //Properties
    public bool HasKey => _hasKey;
    public bool HasCutter => _hasCutter;
    public CarriedItemData CarriedItem => _carriedItem;

    //Events
    [SerializeField] protected UltEvent<GameObject, InventoryEventArgs> OnInventoryUpdated;

    public void SetHasKey(bool hasKey)
    {
        _hasKey = hasKey;
    }

    public void SetHasCutter(bool hasCutter)
    {
        _hasCutter = hasCutter;
    }

    public void SetCarriedItem(CarriedItemData item)
    {
        _carriedItem = item;
        TriggerInventoryUpdate();
    }

    protected void TriggerInventoryUpdate()
    {
        InventoryEventArgs args = new InventoryEventArgs
        {
            Inventory = this
        };
        
        OnInventoryUpdated?.Invoke(gameObject, args);
    }
}