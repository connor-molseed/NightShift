using System.Collections;
using UltEvents;
using UnityEngine;

//TODO Do we split door into its own thing (See InteractableBase.cs)
public class DoorBase : InteractableBase
{
    //Config Parameters
    [SerializeField] protected float _openAngle = 90f;
    [SerializeField] protected float _openDuration = 0.8f;
    [SerializeField] protected bool _lockedOnStart = false;
    [SerializeField] protected GameObject _doorMesh;

    //State Variables
    protected float _closedAngle = 0f;
    protected bool _isOpen = false;
    protected bool _isLocked = false;
    protected Coroutine _curRotRoutine;
    
    //Cached References
    
    //Properties
    public bool IsOpen => _isOpen;
    public bool IsLocked => _isLocked;

    //Events
    [SerializeField] protected UltEvent OnUsedOpen;
    [SerializeField] protected UltEvent OnUsedLocked;
    [SerializeField] protected UltEvent OnUsedClose;

    protected void Awake()
    {
        _isLocked = _lockedOnStart;
    }

    protected override void OnInteractPress(GameObject user)
    {
        Debug.Log("Im pressing a door!");
        UseDoor(user);
    }

    protected override void OnInteractHold(GameObject user)
    {
        Debug.Log("Im holding a door!");
    }

    protected void UseDoor(GameObject user)
    {
        if (_doorMesh == null || user == null) return;
        if (_isLocked)
        {
            OnUsedLocked?.Invoke();
            return;
        }

        if (!_isOpen)
        {
            _isOpen = true;
            OnUsedOpen?.Invoke();
            Vector3 dirToUser = (user.transform.position - transform.position).normalized;
            float dotProduct = Vector3.Dot(transform.forward, dirToUser);
            Quaternion targetRotation = Quaternion.AngleAxis(_openAngle * Mathf.Sign(dotProduct), _doorMesh.transform.up);

            if (_curRotRoutine != null) StopCoroutine(_curRotRoutine);
            _curRotRoutine = StartCoroutine(RotateOverTime(targetRotation, 0.8f));
        }
        else
        {
            _isOpen = false;
            OnUsedClose?.Invoke();
            Quaternion targetRotation = Quaternion.AngleAxis(0, _doorMesh.transform.up);

            if (_curRotRoutine != null) StopCoroutine(_curRotRoutine);
            _curRotRoutine = StartCoroutine(RotateOverTime(targetRotation, 0.8f));
        }
    }

    //Switch to use either a tween or a per door animation for better control
    protected IEnumerator RotateOverTime(Quaternion target, float maxTime)
    {       
        Quaternion startRot = _doorMesh.transform.localRotation; 

        float remainingAngle = Quaternion.Angle(startRot, target);
        float time = maxTime * (remainingAngle/_openAngle); //Get duration relative to any partial rotation

        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / time;
            _doorMesh.transform.localRotation = Quaternion.Slerp(startRot, target, progress);

            yield return null;
        }

        _doorMesh.transform.localRotation = target;
    }
}
