using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour 
{
    private PlayerInput _playerInput;
    public event Action<int> OnWeaponChanged;
    public event Action<Vector2> OnPlayerMoved;
    public event Action<Vector2> OnPlayerRotated;
    public event Action OnFireOpened;
    public event Action OnFireStopped;
    public event Action OnReloaded;
    public event Action OnHealed;


    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.CharacterControls.SetPistol.performed += SetPistol;
        _playerInput.CharacterControls.SetRifle.performed += SetRifle;
        _playerInput.CharacterControls.Shooting.started += OpenFire;
        _playerInput.CharacterControls.Shooting.canceled += StopFire;
        _playerInput.CharacterControls.Reload.performed += Reload;
        _playerInput.CharacterControls.Heal.performed += Heal;
    }

    private void FixedUpdate()
    {
        Move();
        Rotation();
    }
   
    private void Move()
    {
        var moveValue = _playerInput.CharacterControls.Movement.ReadValue<Vector2>();
        OnPlayerMoved?.Invoke(moveValue);
    }

    private void Rotation()
    {
        var rotationValue = _playerInput.CharacterControls.Aiming.ReadValue<Vector2>();
        OnPlayerRotated?.Invoke(rotationValue);
    }

    private void SetPistol(InputAction.CallbackContext context)
    {
        OnWeaponChanged?.Invoke(((int)WeaponsType.Pistol));
    }

    private void SetRifle(InputAction.CallbackContext context)
    {
        OnWeaponChanged?.Invoke(((int)WeaponsType.Rifle));
    }

    private void OpenFire(InputAction.CallbackContext context)
    {
        OnFireOpened?.Invoke();
    }   

    private void StopFire(InputAction.CallbackContext context)
    {
        OnFireStopped?.Invoke();
    }
    private void Reload(InputAction.CallbackContext context)
    {
        OnReloaded?.Invoke();
    }

    private void Heal(InputAction.CallbackContext context)
    {
        OnHealed?.Invoke();
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
