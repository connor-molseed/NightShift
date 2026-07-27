using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Carryable : InteractableBase
{
    private int _originalLayer;
    protected Rigidbody _rb;

    public int OriginalLayer => _originalLayer;

    protected virtual void Awake()
    {
        _originalLayer = gameObject.layer;
        _rb = GetComponent<Rigidbody>();
    }

    public void EnablePhysics(bool enable)
    {
        _rb.useGravity = enable;
        _rb.isKinematic = !enable;
    }

    protected override void OnInteractPress(GameObject user)
    {
        Debug.Log("Insert Pickup Line");
        CarryController carryCont = user.GetComponent<CarryController>();

        if (carryCont)
        {
            carryCont.TryPickupObject(this);
        }
    }
}
