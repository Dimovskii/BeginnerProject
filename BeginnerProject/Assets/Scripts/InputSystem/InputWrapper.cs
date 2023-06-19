using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputWrapper : MonoBehaviour, IInput
{
    private Input _input;
    public event Action<int> OnWeaponChanged;
    public event Action<Vector2> OnPlayerMoved;
    public event Action<Vector2> OnPlayerRotated;
    public event Action OnFireOpened;
    public event Action OnFireStopped;
    public event Action OnReloaded;
    public event Action OnHealed;
    public event Action OnPausePressed;

    private void Awake()
    {
        _input = new Input();
        _input.CharacterControls.SetPistol.performed += SetPistol;
        _input.CharacterControls.SetRifle.performed += SetRifle;
        _input.CharacterControls.Shooting.started += OpenFire;
        _input.CharacterControls.Shooting.canceled += StopFire;
        _input.CharacterControls.Reload.performed += Reload;
        _input.CharacterControls.Heal.performed += Heal;
        _input.UI.Pause.performed += Pause;
    }

    private void Pause(InputAction.CallbackContext context)
    {
        OnPausePressed?.Invoke();
    }

    private void FixedUpdate()
    {
        Move();
        Rotation();
    }
   
    private void Move()
    {
        var moveValue = _input.CharacterControls.Movement.ReadValue<Vector2>();
        OnPlayerMoved?.Invoke(moveValue);
    }

    private void Rotation()
    {
        var rotationValue = _input.CharacterControls.Aiming.ReadValue<Vector2>();
        OnPlayerRotated?.Invoke(rotationValue);
    }

    private void SetPistol(InputAction.CallbackContext context)
    {
        OnWeaponChanged?.Invoke((int)EnumWeaponsType.Pistol);
    }

    private void SetRifle(InputAction.CallbackContext context)
    {
        OnWeaponChanged?.Invoke((int)EnumWeaponsType.Rifle);
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
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }
}
