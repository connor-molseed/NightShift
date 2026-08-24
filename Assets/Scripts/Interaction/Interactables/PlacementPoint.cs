using UnityEngine;

public class PlacementPoint : MonoBehaviour
{
    //Config Parameters
    [SerializeField]
    protected CarriedItemData _placementItemType;
    
    //State Variables
    
    //Cached References
    
    //Properties
    
    //Events
    
    protected void Handle_OnInteractPress(InteractionContext context)
    {
        if (!context.IsPlayer) return;

        Inventory playerInventory = context.User.GetComponent<PlayerController>().Inventory;

        if (playerInventory == null || playerInventory.GetCarriedItem() == null)
        {
            Debug.Log("MISSING ITEM");
        }
        else if (playerInventory.GetCarriedItem()?.UniqueId != _placementItemType.UniqueId)
        {
            Debug.Log("WRONG ITEM");
        }
        else
        {
            Debug.Log("This is the correct item for this spot");
        }
    }
}
