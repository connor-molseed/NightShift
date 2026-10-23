using UnityEngine;

public class ToolPlacementPoint : PlacementPoint
{
    // [SerializeField] Tool _toolType;
    // [SerializeField] bool _startWithItem;

    // bool _hasItem = false;

    // protected override void Handle_OnInteractPress(InteractionContext context)
    // {
    //     if (!context.IsPlayer) return;

    //     PlayerController player = context.User.GetComponent<PlayerController>();

    //     TryPlaceItem(player.Inventory);
    // }

    // protected bool TryTakeItem(Inventory inv)
    // {
    //     if (!_hasItem) return false;


        
    //     return true;
    // }

    // protected override bool TryPlaceItem(Inventory inv)
    // {
    //     return true;
    // }
}

public enum Tool
{
    Storeroom = 0,
    BoxCutter = 1
}