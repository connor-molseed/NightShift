using UnityEngine;

public class PingPongMotion : MonoBehaviour
{
    [SerializeField] Transform _pointA;
    [SerializeField] Transform _pointB;
    [SerializeField] float _speed;

    void Update()
    {
        float totalDistance = Vector3.Distance(_pointA.position, _pointB.position);

        if (totalDistance <= 0.01f) return;

        float adjustedSpeed = _speed / totalDistance;

        float timeFactor = Mathf.PingPong(Time.time * adjustedSpeed, 1f);

        transform.position = Vector3.Lerp(_pointA.position, _pointB.position, timeFactor);
    }
}
