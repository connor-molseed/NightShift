using UnityEngine;

[CreateAssetMenu(fileName = "CarriedItemData", menuName = "Items/Carried Item Data")]
public class CarriedItemData : UniqueIdScriptableObject
{
    [SerializeField] protected string _displayName;
}
