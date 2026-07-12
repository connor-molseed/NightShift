using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    //Config Parameters
    [SerializeField] protected float _baseSpeed = 10f;

    [Header("Placeholder")]
    [SerializeField] protected InputActionReference _moveInputAction;
    
    //State Variables
    
    //Cached References
    CharacterController _charController;

    //Properties   

    //Events


    void Awake()
    {
        _charController = GetComponentInChildren<CharacterController>();
    }


    void Update()
    {
        //Get base movement input relative to forward
        Vector2 moveInput = _moveInputAction.action.ReadValue<Vector2>().normalized;

        //Convert input to relative movement vector
        Vector3 moveVector = InputToMoveVector(moveInput);

        _charController.SimpleMove(moveVector * _baseSpeed);

    }

    Vector3 InputToMoveVector(Vector2 rawInput)
    {
        Vector3 fwdMove = GetForward() * rawInput.y;
        Vector3 strafeMove = GetRight() * rawInput.x;
        
        Vector3 combinedMove = fwdMove + strafeMove;

        return combinedMove;
    }

    public Vector3 GetForward()
    {
        Vector3 camFwd = Camera.main.transform.forward;
        camFwd.y = 0;
        return camFwd.normalized;
    }

    public Vector3 GetRight()
    {
        Vector3 camRight = Camera.main.transform.right;
        camRight.y = 0;
        return camRight.normalized;
    }
}
