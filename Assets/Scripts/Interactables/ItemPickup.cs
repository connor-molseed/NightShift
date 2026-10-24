using Core.Interaction;
using Core.Items;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    //Config Parameters
    [SerializeField] ItemData _item;
    //State Variables
    
    //Cached References
    
    //Properties
    
    //Events
    

    public void Pickup(GameObject user)
    {
        Inventory inv = user.GetComponent<Inventory>();
        CarryController carry = user.GetComponent<CarryController>();

        if (inv == null) return;

        if (_item.IsCarried && carry != null)
        {
            bool canPickup = carry.TryPickupObject(GetComponent<Carryable>());
            if (!canPickup) return;
        }
        else if (inv.AddItem(_item))
        {
            Debug.Log($"{0} was added to inventory");
        }
    }
}