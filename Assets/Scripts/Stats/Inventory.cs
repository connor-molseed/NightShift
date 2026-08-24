using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Config Parameters
    
    //State Variables
    [SerializeField] protected bool _hasKey = true;
    [SerializeField] protected bool _hasCutter = true;
    
    //Cached References
    protected CarryController _carryController;
    
    //Properties
    public bool HasKey => _hasKey;
    public bool HasCutter => _hasCutter;

    //Events

    protected void Awake()
    {
        _carryController = GetComponent<CarryController>();
    }

    public void SetHasKey(bool hasKey)
    {
        _hasKey = hasKey;
    }

    public void SetHasCutter(bool hasCutter)
    {
        _hasCutter = hasCutter;
    }

    public CarriedItemData GetCarriedItem()
    {
        if (_carryController == null || _carryController.CarriedItem == null) return null;

        return _carryController.CarriedItem.ItemData;
    }
}