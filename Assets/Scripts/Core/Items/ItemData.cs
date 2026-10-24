using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Items
{
    [CreateAssetMenu(fileName = "CarriedItemData", menuName = "Items/Carried Item Data")]
    public class ItemData : UniqueIdScriptableObject
    {
        [SerializeField] protected string _displayName;
        [SerializeField, FormerlySerializedAs("_heldItem")] protected bool _isCarried;
    
        public string DisplayName => _displayName;
        public bool IsCarried => _isCarried;
    }
}
