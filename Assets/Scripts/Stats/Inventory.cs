using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected bool _hasKey = true;
    [SerializeField] protected bool _hasCutter = true;

    //properties
    public bool HasKey => _hasKey;
    public bool HasCutter => _hasCutter;
}