using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _smoothSpeed = 0.1f;
    [SerializeField] private Vector3 _offset;

    public void Init(Transform target) 
    {
        _offset = new Vector3(0, 70, -74);
        _target = target;
    }

    private void LateUpdate() 
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        var desiredPosition = _target.position + _offset;
        var smootedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smootedPosition;
    }
}
