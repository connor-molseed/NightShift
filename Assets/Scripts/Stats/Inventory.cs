using System.Collections.Generic;
using UltEvents;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Config Parameters
    
    //State Variables
    [SerializeField] protected bool _hasKey = true;
    [SerializeField] protected bool _hasCutter = true;
    [SerializeField] protected List<CarriedItemData> _items;
    [SerializeField] protected CarriedItemData _carriedItem;
    
    //Cached References

    
    //Properties
    public bool HasKey => _hasKey;
    public bool HasCutter => _hasCutter;
    //public CarriedItemData CarriedItem => _carriedItem;

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

    // public void SetCarriedItem(CarriedItemData item)
    // {
    //     _carriedItem = item;
    //     TriggerInventoryUpdate();
    // }

    public void AddItem(CarriedItemData item)
    {
        _items.Add(item);
        TriggerInventoryUpdate();
    }

    public void RemoveItem(CarriedItemData item)
    {
        _items.Remove(item);
        TriggerInventoryUpdate();
    }

    public bool ContainsItem(CarriedItemData item)
    {
        return _items.Contains(item);
    }

    protected void TriggerInventoryUpdate()
    {
        InventoryEventArgs args = new InventoryEventArgs
        {
            Inventory = this
        };
        
        OnInventoryUpdated?.Invoke(gameObject, args);
    }

    // public bool HasTool(Tool tool)
    // {
    //     return true;
    // }
}