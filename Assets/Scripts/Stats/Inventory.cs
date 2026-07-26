using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected bool _hasKey = true;

    //properties
    public bool HasKey => _hasKey;
}