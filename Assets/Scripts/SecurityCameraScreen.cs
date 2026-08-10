using UnityEngine;
using UnityEngine.InputSystem;

public class SecurityCameraScreen : MonoBehaviour
{
    //Config Parameters
    [SerializeField] protected InputActionReference _closeUIInput;
    [SerializeField] protected CanvasGroup _UICanvas;
    
    //State Variables
    
    //Cached References
    protected PlayerController _player;

    //Properties

    //Events

    void Awake()
    {
        _UICanvas.alpha = 0;
    }

    void Start()
    {
        _player = FindAnyObjectByType<PlayerController>();
    }

    public void EnableUI()
    {
        _UICanvas.alpha = 1;
        _player.EnableControl(false);

        _closeUIInput.action.Enable();
        _closeUIInput.action.performed += OnCloseUIPressed;
    }

    public void DisableUI()
    {
        _player.EnableControl(true);
        _UICanvas.alpha = 0;

        _closeUIInput.action.performed -= OnCloseUIPressed;
    }

    protected void OnCloseUIPressed(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        DisableUI();
    }
}
