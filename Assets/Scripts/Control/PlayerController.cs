using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Config Parameters
    
    //State Variables
    
    //Cached References
    protected Mover _mover;
    protected Looker _looker;
    protected InteractionController _interactor;
    protected Inventory _inventory;

    //Properties
    public Inventory Inventory => _inventory;

    //Events

    protected void Awake()
    {
        _mover = GetComponent<Mover>();
        _looker = GetComponent<Looker>();
        _interactor = GetComponent<InteractionController>();
        _inventory = GetComponent<Inventory>();
    }

    public void EnableControl(bool enable)
    {
        _mover.enabled = enable;
        _looker.enabled = enable;
        _interactor.enabled = enable;
    }
}
