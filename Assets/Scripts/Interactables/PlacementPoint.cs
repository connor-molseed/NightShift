using UnityEngine;

using Core.Items;
using Core.Interaction;

public class PlacementPoint : MonoBehaviour
{
    //Config Parameters
    [SerializeField] protected ItemData _itemType;
    [SerializeField] protected GameObject _placementOutline;
    [SerializeField] protected Interactable _interaction;
    
    //State Variables
    
    //Cached References
    
    //Properties
    
    //Events

    private void Awake()
    {
        EnablePlacementPoint(false);
    }

    public void Handle_OnInventoryChanged(InventoryEventArgs args)
    {
        bool itemMatches = args.Inventory.ContainsItem(_itemType);

        EnablePlacementPoint(itemMatches);
    }
    
    public void Handle_OnInteractPress(InteractionContext context)
    {
        Inventory inv = context.User.GetComponent<Inventory>();
        if (inv == null) return;

        if (inv.ContainsItem(_itemType))
        {
            TryPlaceItem(inv);
        }
        else
        {
            Debug.Log("Not carrying the correct item");
        }
    }

    protected bool TryPlaceItem(Inventory inv)
    {
        inv.RemoveItem(_itemType);

        if (_itemType.IsCarried)
        {
            Carryable _carriedItem = inv.gameObject.GetComponent<CarryController>().RemoveCarriedItem();
            _carriedItem.gameObject.SetActive(false);
        }

        return true;
    }

    protected void EnablePlacementPoint(bool enable)
    {
        Debug.Log($"Item Matches: {enable}");
        _placementOutline.SetActive(enable);
        _interaction.IsEnabled = enable;
    }

    //protected bool 
}
