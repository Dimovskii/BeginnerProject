using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private float _smoothSpeed = 0.1f;
    private Vector3 _offset;
    public Transform Player { get ; set ; }

    private void Awake()
    {
        _offset = new Vector3(0, 70, -74);
    }

    private void LateUpdate() 
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        if(Player != null)
        {
            var desiredPosition = Player.position + _offset;
            var smootedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smootedPosition;
        }
    }
}
