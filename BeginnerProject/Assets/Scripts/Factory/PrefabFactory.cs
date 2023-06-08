using UnityEngine;
using System.Collections.Generic;
using Factory;

public class PrefabFactory : MonoBehaviour
{
    [SerializeField] private GameObject _ground;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _uiRoot;

    private Dictionary<string, GameObject> _gameObjects;
    
    private void Awake()
    {
        _gameObjects = new Dictionary<string, GameObject>
        {
            { GameConstants.Ground, _ground },
            { GameConstants.Player, _player },
            { GameConstants.Camera, _camera },
            { GameConstants.Enemy, _enemy },
            { GameConstants.UIRoot, _uiRoot }
        };
    }

    public GameObject Create(string key)
    {
        if (!_gameObjects.TryGetValue(key, out GameObject value))
        {
            Debug.LogError($"Prefab with key {key} not found.");
            return null;
        }
        else
        {
            return Instantiate(value);
        }
    }
}