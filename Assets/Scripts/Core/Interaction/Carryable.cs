using System;
using UnityEngine;
using Core.Items;
using Core.Interaction;

[RequireComponent(typeof(Rigidbody))]
public class Carryable : MonoBehaviour, IInteractable
{
    //Config Parameters
    [SerializeField] private ItemData _itemData;

    //State Variables
    private bool _isInteractable = true;
    private bool _isCarried = false;

    //Cached References
    private int _originalLayer;
    private Rigidbody _rb;

    //Properties
    public int OriginalLayer => _originalLayer;
    public Transform Root => transform;
    public ItemData ItemData => _itemData;
    public string DisplayName => _itemData.name;
    public bool IsInteractable => _isInteractable;

    //Events

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

    public bool Pickup()
    {
        EnablePhysics(false);
        _isCarried = true;
        _isInteractable = false;
        return true;
    }

    public bool Drop()
    {
        EnablePhysics(true);
        _isCarried = false;
        _isInteractable = true;
        return true;
    }

    public virtual bool InteractPress(InteractionContext context)
    {
        Debug.Log("No press interaction assigned");

        if (!_isInteractable) return false;
        Debug.Log("No press interaction assigned");
        return true;
    }

    public virtual bool InteractHold(InteractionContext context)
    {
        if (!_isInteractable) return false;

        CarryController carrier = context.User.GetComponent<CarryController>();
        if (carrier == null) return false;

        carrier.TryPickupObject(this);
        return true;
    }
}
