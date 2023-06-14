using Factory;
using Infrastructure;
using UnityEngine;

namespace Infrastructure
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PrefabFactory _factory;
        private Player _player;

        private void Awake()
        {
            CreateGameObjects();
        }

        private void CreateGameObjects()
        {
            var groundPrefab = _factory.Create(GameConstants.Ground);
            var playerPrefab = _factory.Create(GameConstants.Player);
            var playerTransform = playerPrefab.transform;
            
            var cameraPrefab = _factory.Create(GameConstants.Camera);
            var camera = cameraPrefab.GetComponent<Camera>();
            cameraPrefab.GetComponent<CameraFollower>().Player = playerTransform;

            _player = playerPrefab.GetComponent<Player>();
            _player.PlayerMovement.Camera = camera;

            var uiRootPrefab = _factory.Create(GameConstants.UIRoot);
            var uiRoot = uiRootPrefab.GetComponent<UIRoot>();
            uiRoot.Init(_player.PlayerHealth, _player.Input, _player.Shooting, _player.Reload, _player.WeaponSwitcher);

            groundPrefab.GetComponent<EnemySpawner>().Init(_factory, playerTransform);
        }
    }
}
