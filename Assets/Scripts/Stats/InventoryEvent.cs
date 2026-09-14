using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Global Events/Inventory Event", fileName = "NewInventoryEvent")]
public class InventoryEvent : GlobalEvent<InventoryEventArgs> { }

public struct InventoryEventArgs
{
    public Inventory Inventory;
}