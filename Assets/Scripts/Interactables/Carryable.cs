using System;
using UnityEngine;
using Core.Items;

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

    public void EnablePhysics(bool enable)
    {
        _rb.useGravity = enable;
        _rb.isKinematic = !enable;
    }
}
