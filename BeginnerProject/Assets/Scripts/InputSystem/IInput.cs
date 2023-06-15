using System;
using UnityEngine;

public interface IInput
{
    event Action<int> OnWeaponChanged;
    event Action<Vector2> OnPlayerMoved;
    event Action<Vector2> OnPlayerRotated;
    event Action OnFireOpened;
    event Action OnFireStopped;
    event Action OnReloaded;
    event Action OnHealed;
    event Action OnPausePressed;
}