using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerMovement
{
    [SerializeField] private float _moveSpeed = 40f;
    [SerializeField] private float _rotationSpeed = 10f;
    private IInput _input;
    private Camera _camera;
    public Camera Camera { get => _camera; set => _camera = value; }

    public void Init(IInput input)
    {
        _input = input;
        Discribe();
    }

    private void Discribe()
    {
        _input.OnPlayerMoved += Move;
        _input.OnPlayerRotated += Rotation;
    }

    private void Move(Vector2 value)
    {
        var moveDirecion = new Vector3(value.x, 0, value.y);
        transform.position += moveDirecion * _moveSpeed * Time.deltaTime;
    }

    private void Rotation(Vector2 value)
    {
        var ray = _camera.ScreenPointToRay(value);
        var plane = new Plane(Vector3.up, transform.position);

        if (plane.Raycast(ray, out float distance))
        {
            var worldposition = ray.GetPoint(distance);
            var targetrotation = Quaternion.LookRotation(worldposition - transform.position);
            targetrotation.x = 0f;
            targetrotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        _input.OnPlayerMoved -= Move;
        _input.OnPlayerRotated -= Rotation;
    }
}