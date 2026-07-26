using UnityEngine;

public class Carryable : InteractableBase
{
    private int originalLayer;

    public int OriginalLayer => originalLayer;

    protected virtual void Awake()
    {
        originalLayer = gameObject.layer;
    }

    protected override void OnInteractPress(GameObject user)
    {
        Debug.Log("Insert Pickup Line");
        CarryController carryCont = user.GetComponent<CarryController>();

        if (carryCont)
        {
            carryCont.PickupObject(this);
        }
    }
}
