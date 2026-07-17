using UnityEngine;
using UnityEngine.InputSystem;

public class Looker : MonoBehaviour
{
    //Config Parameters
    [SerializeField] protected float _hSensitivity;
    [SerializeField] protected float _vSensitivity;
    [SerializeField, Range(0f, 90f)] protected float minCamPitch;
    [SerializeField, Range(0f, 90f)] protected float maxCamPitch;

    [Header("Placeholder")]
    [SerializeField] protected InputActionReference _viewInputAction;
    
    //State Variables
    protected float _cameraPitch;
    
    //Cached References
    protected Camera _camera;

    //Properties

    //Events

    void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        Vector2 cameraInput = _viewInputAction.action.ReadValue<Vector2>();

        UpdateRotation(cameraInput.x);
        UpdatePitch(cameraInput.y);
    }

    protected void UpdateRotation(float input)
    {
        float rotDelta = input * _hSensitivity;
        transform.Rotate(transform.up, rotDelta); 
    }

    protected void UpdatePitch(float input)
    {
        _cameraPitch += -input * _vSensitivity;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -maxCamPitch, minCamPitch);

        _camera.transform.localRotation = Quaternion.Euler(_cameraPitch, 0, 0);
    }
}