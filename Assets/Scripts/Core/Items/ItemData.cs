using UnityEngine;
using UnityEngine.Serialization;

//LArge items that can only be carried at all times??

namespace Core.Items
{
    [CreateAssetMenu(fileName = "CarriedItemData", menuName = "Items/Carried Item Data")]
    public class ItemData : UniqueIdScriptableObject
    {
        [SerializeField] protected string _displayName;
        [SerializeField, FormerlySerializedAs("_heldItem")] protected bool _isCarried;
        [SerializeField] protected Sprite _icon;

    
        public string DisplayName => _displayName;
        public bool IsCarried => _isCarried;
        public Sprite Icon => _icon;
    }
}
