using UnityEngine;

public class CarryablePlacementPoint : PlacementPoint
{
    // [SerializeField] protected CarriedItemData _placementItemType;

    // protected void Handle_OnCarriedItemChanged(InventoryEventArgs args)
    // {
    //     bool itemMatches = args.Inventory.CarriedItem?.UniqueId == _placementItemType.UniqueId;

    //     EnablePlacementPoint(itemMatches);
    // }

    // protected override void Handle_OnInteractPress(InteractionContext context)
    // {
    //     if (!context.IsPlayer) return;

    //     CarryController carryCont = context.User.GetComponent<CarryController>();

    //     if (carryCont == null || carryCont.CarriedItem == null)
    //     {
    //         Debug.Log("MISSING ITEM");
    //     }
    //     else if (carryCont.CarriedItem.ItemData.UniqueId != _placementItemType.UniqueId)
    //     {
    //         Debug.Log("WRONG ITEM");
    //     }
    //     else
    //     {
    //         Debug.Log("This is the correct item for this spot");
            
    //         carryCont.RemoveCarriedItem().gameObject.SetActive(false);
    //         //EnablePlacementPoint(false);
    //     }
    // }

    // protected override bool TryPlaceItem(Inventory inv)
    // {
    //     return true;   
    // }
}