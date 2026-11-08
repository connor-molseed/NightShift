using System;
using UnityEngine;
using Core.Items;

[RequireComponent(typeof(Rigidbody))]
public class Carryable : MonoBehaviour
{
    //Config Parameters
    [SerializeField] private ItemData itemData;

    //State Variables
    

    //Cached References
    private int _originalLayer;
    private Rigidbody _rb;

    //Properties
    public int OriginalLayer => _originalLayer;
    public Transform Root => transform;
    public ItemData ItemData => itemData;

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
        return true;
    }

    public bool Drop()
    {
        EnablePhysics(true);
        return true;
    }
}
