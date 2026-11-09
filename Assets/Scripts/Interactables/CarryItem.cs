using Core.Interaction;
using UnityEngine;

public class CarriedItemInteraction : MonoBehaviour, IInteractable
{
    //Config Parameters
    [SerializeField] Carryable _item;





    //State Variables

    //Cached References

    //Properties
    public string DisplayName => _item.ItemData.name;
    public bool IsInteractable => true;

    //Events

    public bool InteractHold(InteractionContext context)
    {
        throw new System.NotImplementedException();
    }

    public bool InteractPress(InteractionContext context)
    {
        throw new System.NotImplementedException();
    }

    void PickupCarryable(GameObject user)
    {
        CarryController carrier = user.GetComponent<CarryController>();
        if (carrier == null) return;

        carrier.TryPickupObject(_item);
    }
}