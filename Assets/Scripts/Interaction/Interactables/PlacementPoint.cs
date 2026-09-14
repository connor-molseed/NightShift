using UnityEngine;

public class PlacementPoint : MonoBehaviour
{
    //Config Parameters
    [SerializeField]
    protected CarriedItemData _placementItemType;
    [SerializeField]
    protected GameObject _placementOutline;
    [SerializeField]
    protected Interaction _interaction;
    
    //State Variables
    
    //Cached References
    
    //Properties
    
    //Events

    protected void Awake()
    {
        EnablePlacementPoint(false);
    }
    
    protected void Handle_OnInteractPress(InteractionContext context)
    {
        if (!context.IsPlayer) return;

        Inventory playerInventory = context.User.GetComponent<PlayerController>().Inventory;

        if (playerInventory == null || playerInventory.CarriedItem == null)
        {
            Debug.Log("MISSING ITEM");
        }
        else if (playerInventory.CarriedItem?.UniqueId != _placementItemType.UniqueId)
        {
            Debug.Log("WRONG ITEM");
        }
        else
        {
            Debug.Log("This is the correct item for this spot");
        }
    }

    protected void Handle_OnCarriedItemChanged(InventoryEventArgs args)
    {
        bool itemMatches = args.Inventory.CarriedItem?.UniqueId == _placementItemType.UniqueId;

        EnablePlacementPoint(itemMatches);
    }

    protected void EnablePlacementPoint(bool enable)
    {
        Debug.Log($"Item Matches: {enable}");
        _placementOutline.SetActive(enable);
        _interaction.IsEnabled = enable;
    }
}
