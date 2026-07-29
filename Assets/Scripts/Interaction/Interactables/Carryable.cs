using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Carryable : MonoBehaviour
{
    private int _originalLayer;
    protected Rigidbody _rb;

    public int OriginalLayer => _originalLayer;

    protected virtual void Awake()
    {
        _originalLayer = gameObject.layer;
        _rb = GetComponent<Rigidbody>();
    }

    protected void Handle_OnInteractPress(InteractionContext context)
    {
        TryPickupObject(context.User);
    }

    public void EnablePhysics(bool enable)
    {
        _rb.useGravity = enable;
        _rb.isKinematic = !enable;
    }

    public bool TryPickupObject(GameObject carrier)
    {
        Debug.Log("Insert Pickup Line");
        CarryController carryCont = carrier.GetComponent<CarryController>();

        if (carryCont)
        {
            return carryCont.TryPickupObject(this);
        }

        return false;
    }
}
