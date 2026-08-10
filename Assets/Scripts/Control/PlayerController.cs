using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Config Parameters
    
    //State Variables
    
    //Cached References
    protected Mover _mover;
    protected Looker _looker;
    protected InteractionController _interactor;

    //Properties

    //Events

    protected void Awake()
    {
        _mover = GetComponent<Mover>();
        _looker = GetComponent<Looker>();
        _interactor = GetComponent<InteractionController>();
    }

    public void EnableControl(bool enable)
    {
        _mover.enabled = enable;
        _looker.enabled = enable;
        _interactor.enabled = enable;
    }
}
