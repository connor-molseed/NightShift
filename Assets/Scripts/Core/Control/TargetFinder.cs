using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    //Config Parameters
    [SerializeField] private float _maxDistance = 10f;
    [SerializeField] private float _checkRadius = 0.2f;
    [SerializeField] private LayerMask _ignoreLayers;

    //State Variables
    [SerializeField]
    private GameObject _target;
    
    //Cached References
    private Transform _origin;
    
    //Properties
    public GameObject Target => _target;
    
    //Events

    void Start()
    {
        if (!_origin) _origin = Camera.main.transform;
    }

    void Update()
    {
        if (!_origin) return;
    
        Ray ray = new Ray(_origin.transform.position, _origin.transform.forward);
        RaycastHit hit;
    
        if (Physics.SphereCast(ray, _checkRadius, out hit, _maxDistance, ~_ignoreLayers))
        {
            if (hit.collider.attachedRigidbody != null)
                _target = hit.collider.attachedRigidbody.gameObject;
            else
                _target = hit.collider.gameObject;
        }  
        else
        {
            _target = null;
        }
    }

    public static implicit operator GameObject(TargetFinder value) => value.Target;
}
