using Assets.Scripts;
using Factory;
using UnityEngine;
using Weapon;

namespace Infrastructure

{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private GameObject _hudPrefab;
        [SerializeField] private GameObject _pauseMenuPrefab;
        [SerializeField] private GameObject _gameOverScrenPrefab;
        private IPlayerHealth _playerHealth;
        private IInput _input;
        private IShoot _shooting;
        private IReload _reload;
        private ISwitcher _switcher;

        public void Init(IPlayerHealth playerHealth, IInput input, IShoot shoot, IReload reload, ISwitcher switcher)
        {
            _playerHealth = playerHealth;
            _input = input;
            _shooting = shoot;
            _reload = reload;
            _switcher = switcher;
            CreateViews();
        }

        private void CreateViews()
        {
            var uiRoot = gameObject.transform;
            GameObjectFactory factory = new GameObjectFactory();

            var hudPrefab = factory.CreateView(_hudPrefab, uiRoot);
            hudPrefab.GetComponent<HealthBar>().Init(_playerHealth);
            hudPrefab.GetComponent<WeaponBar>().Init(_shooting, _input, _reload, _switcher);

            var pauseMenuPrefab = factory.CreateView(_pauseMenuPrefab, uiRoot);
            pauseMenuPrefab.GetComponent<PauseMenu>().Init(_input);

            var gameOverScreenPrefab = factory.CreateView(_gameOverScrenPrefab, uiRoot);
            gameOverScreenPrefab.GetComponent<GameOverScreen>().Init(_playerHealth);
        }
    }
}