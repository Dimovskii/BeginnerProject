using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] private float _moveSpeed = 40f;
    [SerializeField] private float _rotationSpeed = 10f;
    private InputHandler _inputHandler;
    private Camera _camera;

    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _inputHandler.OnPlayerMoved += Move;
        _inputHandler.OnPlayerRotated += Rotation;
    }

    private void Move(Vector2 value)
    {
        var moveDirecion = new Vector3(value.x, 0, value.y);
        transform.position += moveDirecion * _moveSpeed * Time.deltaTime;
    }

    private void Rotation(Vector2 value)
    {
        Ray ray = _camera.ScreenPointToRay(value);
        Plane plane = new Plane(Vector3.up, transform.position);

        if (plane.Raycast(ray, out float distance))
        {
            var worldPosition = ray.GetPoint(distance);
            var targetRotation = Quaternion.LookRotation(worldPosition - transform.position);
            targetRotation.x = 0f;
            targetRotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        _inputHandler.OnPlayerMoved -= Move;
        _inputHandler.OnPlayerRotated -= Rotation;
    }
}