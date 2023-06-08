using Factory;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private PrefabFactory _factory;

    private void Start()
    {
        CreateGameObjects();
    }

    private void CreateGameObjects()
    {
        _factory.Create(GameConstants.Ground);
        _factory.Create(GameConstants.Player);
        _factory.Create(GameConstants.Camera);
        //var rotation = _player.GetRotator();
        //rotation.Init(_cameraPrefab.GetComponent<Camera>());
        //_factory.Create(GameConstants.UIRoot);

        //var playerTransform = _playerPrefab.transform;
        //_cameraPrefab.GetComponent<CameraFollower>().PlayerTransform = playerTransform;
        //_groundPrefab.GetComponent<EnemySpawner>().Init(_factory, playerTransform);
    }
}
