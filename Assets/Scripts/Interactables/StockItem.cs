using Core.Interaction;
using UnityEngine;

[RequireComponent(typeof(Carryable))]
public class StockItem : MonoBehaviour, IInteractable
{
    //Config Parameters
    
    //State Variables
    
    //Cached References
    protected Carryable _carryable;

    //Properties

    //Events


    public string DisplayName => _carryable.name;

    public bool IsInteractable => true;

    void Awake()
    {
        _carryable = GetComponent<Carryable>();
    }

    public bool InteractPress(InteractionContext context)
    {
        if (!IsInteractable) return false;
        Debug.Log("No press interaction assigned");
        return true;
    }

    public bool InteractHold(InteractionContext context)
    {
        if (!IsInteractable) return false;

        CarryController carrier = context.User.GetComponent<CarryController>();
        if (carrier == null) return false;

        carrier.TryPickupObject(_carryable);
        return true;
    }
}