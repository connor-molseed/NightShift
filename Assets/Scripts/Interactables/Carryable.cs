using System;
using UnityEngine;
using Core.Items;

[RequireComponent(typeof(Rigidbody))]
public class Carryable : MonoBehaviour
{
    [SerializeField] protected ItemData _itemData;

    private int _originalLayer;
    protected Rigidbody _rb;

    public ItemData ItemData => _itemData;
    public int OriginalLayer => _originalLayer;

    protected virtual void Awake()
    {
        _originalLayer = gameObject.layer;
        _rb = GetComponent<Rigidbody>();
    }

    protected void Handle_OnInteractPress(GameObject user)
    {
        TryPickupObject(user);
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
