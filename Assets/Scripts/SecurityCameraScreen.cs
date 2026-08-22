using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//TODO cameras bypass update frequency by switching back/forth. could use class that handles render update independantly 
public class SecurityCameraScreen : MonoBehaviour
{
    //Config Parameters
    [SerializeField] protected List<Camera> _cameras = new List<Camera>();
    [SerializeField] protected float _updateDelay = 0.4f;
    [SerializeField] protected InputActionReference _cycleCameraInput;
    [SerializeField] protected InputActionReference _closeUIInput;
    [SerializeField] protected CanvasGroup _UICanvas;
    
    //State Variables
    protected int _curCameraIndex = 0;
    
    //Cached References
    protected PlayerController _player;
    protected Coroutine _renderCoroutine;

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
        EnableCurrentCamera();

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
        DisableCurrentCamera();
        
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
        if (newCameraIndex == _curCameraIndex && _renderCoroutine != null) return;
        
        DisableCurrentCamera();
        _curCameraIndex = newCameraIndex;
        EnableCurrentCamera();
    }

    protected void EnableCurrentCamera()
    {
        if (_updateDelay > float.Epsilon)
            _renderCoroutine = StartCoroutine(CameraUpdateCoroutine());
        else
            _cameras[_curCameraIndex].enabled = true;
    }

    protected void DisableCurrentCamera()
    {
        if (_renderCoroutine != null)
        {
            StopCoroutine(_renderCoroutine);
            _renderCoroutine = null;
        }
        _cameras[_curCameraIndex].enabled = false;
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

    protected IEnumerator CameraUpdateCoroutine()
    {
        Camera activeCam = _cameras[_curCameraIndex];

        while(true)
        {
            activeCam.Render();
            yield return new WaitForSeconds(_updateDelay);
        }
    }
}
