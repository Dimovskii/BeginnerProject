using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 40f;
    [SerializeField] private float _rotationSpeed = 10f;
    private Camera _camera;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _camera = Camera.main;
    }
   
    private void FixedUpdate()
    {
        Move();
        Rotation();
    }


    private void Move()
    {
        var direction = _playerInput.CharacterControls.Movement.ReadValue<Vector2>();
        var scaledMoveSpeed = _moveSpeed * Time.deltaTime;

        var moveDirecion = new Vector3(direction.x, 0, direction.y);
        transform.position += moveDirecion * _moveSpeed * Time.deltaTime;
    }

    private void Rotation()
    {
        var mouseScreenPosition = _playerInput.CharacterControls.Aiming.ReadValue<Vector2>();
        Ray ray = _camera.ScreenPointToRay(mouseScreenPosition);
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

     private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}