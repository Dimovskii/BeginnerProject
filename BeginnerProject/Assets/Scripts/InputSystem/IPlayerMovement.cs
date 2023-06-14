using UnityEngine;

public interface IPlayerMovement
{
    Camera Camera { get ; set ; }
    void Init(IInput input);
}