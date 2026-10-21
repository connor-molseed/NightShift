using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "CarriedItemData", menuName = "Items/Carried Item Data")]
public class CarriedItemData : UniqueIdScriptableObject
{
    [SerializeField] protected string _displayName;
    [SerializeField, FormerlySerializedAs("_heldItem")] protected bool _isCarried;

    public string DisplayName => _displayName;
    public bool IsCarried => _isCarried;
}
