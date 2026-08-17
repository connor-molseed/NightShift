using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SecurityCameraScreen : MonoBehaviour
{
    //Config Parameters
    [SerializeField] protected List<Camera> _cameras = new List<Camera>();

    [SerializeField] protected InputActionReference _cycleCameraInput;
    [SerializeField] protected InputActionReference _closeUIInput;
    [SerializeField] protected CanvasGroup _UICanvas;
    
    //State Variables
    protected int _curCameraIndex = 0;
    
    //Cached References
    protected PlayerController _player;

    //Properties

    //Events

    void Awake()
    {
        _UICanvas.alpha = 0;

        foreach(Camera c in _cameras)
        {
            c.enabled = false;
        }
    }

    void Start()
    {
        _player = FindAnyObjectByType<PlayerController>();
    }

    public void EnableUI()
    {
        ForceActiveCamera(_curCameraIndex);

        _UICanvas.alpha = 1;
        _player.EnableControl(false);

        _closeUIInput.action.Enable();
        _closeUIInput.action.performed += OnCloseUIPressed;
        _cycleCameraInput.action.Enable();
        _cycleCameraInput.action.performed += OnCycleCameraPressed;
    }

    public void ForceActiveCamera(int index)
    {
        if (index < 0 ||index >= _cameras.Count)
        {
            Debug.Log("Camera index is out of bounds");
            return;
        }

        SwitchActiveCamera(index);
    }

    public void DisableUI()
    {
        _player.EnableControl(true);
        _UICanvas.alpha = 0;

        _closeUIInput.action.performed -= OnCloseUIPressed;
        _cycleCameraInput.action.performed -= OnCycleCameraPressed;
    }

    protected void OnCloseUIPressed(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        DisableUI();
    }

    //TODO: reading as int truncates value, will cause issues with analogue sticks. Fix at some point
    protected void OnCycleCameraPressed(InputAction.CallbackContext context)
    {
        int value = (int) context.ReadValue<float>();

        Debug.Log($"Input happened, value: {value}");

        if (value == 0) return;
        else if (value > 0) CycleNextCamera();
        else CyclePrevCamera();
    }

    protected void SwitchActiveCamera(int newCameraIndex)
    {
        //Clean up currently active camera
        _cameras[_curCameraIndex].enabled = false;
        
        _curCameraIndex = newCameraIndex;

        //Activate new camera
        _cameras[_curCameraIndex].enabled = true;

        //Do something to stop process of new update enumerator if new and old are the same
        //With slow updates, cameras aren't active, instead them get pushed to update, so may be simpler
        //if (newCameraIndex == _curCameraIndex) return;
    }

    protected void CycleNextCamera()
    {
        int newIndex = (_curCameraIndex + 1) % _cameras.Count;

        SwitchActiveCamera(newIndex);
    }

    protected void CyclePrevCamera()
    {
        int newIndex = _curCameraIndex > 0 ? _curCameraIndex - 1 : _cameras.Count - 1;

        SwitchActiveCamera(newIndex);
    }
}
