using Weapon;
using UnityEngine;

namespace Infrastructure
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputWrapper _input;
        [SerializeField] private Shooting _shooting;
        [SerializeField] private WeaponSwitcher _weaponSwitcher;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private Reload _reload;

        public ISwitcher WeaponSwitcher => _weaponSwitcher;
        public IInput Input => _input;
        public IShoot Shooting => _shooting;
        public IPlayerMovement PlayerMovement => _playerMovement;
        public IPlayerHealth PlayerHealth => _playerHealth;
        public IReload Reload => _reload;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            PlayerMovement.Init(Input);
            WeaponSwitcher.Init(Input);
            Shooting.Init(Input, WeaponSwitcher);
            Reload.Init(Input, WeaponSwitcher);
            PlayerHealth.Init(Input);
        }

    }
}