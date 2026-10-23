using System;
using UnityEngine;
using Core.Items;

[Serializable]
[CreateAssetMenu(menuName = "Global Events/Inventory Event", fileName = "NewInventoryEvent")]
public class InventoryEvent : GlobalEvent<InventoryEventArgs> { }

public struct InventoryEventArgs
{
    public Inventory Inventory;
}