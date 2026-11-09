using UnityEngine;
using Core.Interaction;
using Core.Items;

//TODO Fix on hold interaction behaviour (currently only works if box is sealed)
public class BoxOfStock : Carryable
{
    //Config Parameters
    [SerializeField] protected bool _startSealed;
    [Header("Contents")]
    [SerializeField] protected Carryable _stockPrefab;
    [SerializeField] protected int _totalStock;

    [Header("Animation")]
    [SerializeField] protected string _paramIsOpen;
    
    //State Variables
    [SerializeField] protected bool _isSealed;
    [SerializeField] protected int _remainingStock;
    
    //Cached References
    protected Animator _animator;
    protected int ap_IsOpen;
    
    //Properties
    public bool IsSealed => _isSealed;

    //Events


    protected override void Awake()
    {      
        base.Awake();

        _isSealed = _startSealed;

        _animator = GetComponent<Animator>();

        ap_IsOpen = Animator.StringToHash(_paramIsOpen);
    }

    public override bool InteractPress(InteractionContext context)
    {
        if (_isSealed)
            return TryUnsealBox(context.User);
        else
            return TryRemoveStock(context.User);
    }

    // public bool InteractHold(InteractionContext context)
    // {
    //     if (_isSealed)
    //         return TryUnsealBox(context.User);
    //     else
    //         return TryRemoveStock(context.User);
    // }

    public bool TryUnsealBox(GameObject user)
    {
        if (UserHasCutter(user))
        {
            _isSealed = false;
            _animator.SetBool(ap_IsOpen, true);

            _remainingStock = _totalStock;
            return true;
        }
        return false;
    }

    public bool TryRemoveStock(GameObject user)
    {
        if (_remainingStock <= 0) return false;
        
        CarryController carrier = user.GetComponent<CarryController>();

        if (carrier != null && !carrier.IsCarryingItem)
        {
            _remainingStock--;
            Carryable newStock = Instantiate(_stockPrefab);
            carrier.TryPickupObject(newStock);
            return true;
        }

        return false;
    }

    protected bool UserHasCutter(GameObject user)
    {
        return true;
        Inventory userInv = user.GetComponent<Inventory>();

        if (userInv != null)
        {
            return userInv.HasCutter;
        }
        return false;
    }


}
