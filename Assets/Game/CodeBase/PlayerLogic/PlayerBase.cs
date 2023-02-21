using Game.CodeBase.Common;
using Game.CodeBase.Core.Services;
using Game.CodeBase.Weapon.Guns;
using UnityEngine;

namespace Game.CodeBase.PlayerLogic
{
    public class PlayerBase : MonoBehaviour, IPlayer
    {
        [SerializeField] private PlayerSettings playerSettings;
        private PlayerMovement _playerMovement;
        
        private IHealth _playerHealth;
        private IInputService _inputService;
        private IGun _gun;
        
        public IInputService InputService { get; set; }
        public IHealth PlayerHealth => _playerHealth;
        public IGun Gun => _gun;
      
        private void Awake()
        {
            _inputService = GetComponent<IInputService>();
            _playerHealth = GetComponent<IHealth>();
            _gun = GetComponentInChildren<IGun>();
        
            _playerMovement = new PlayerMovement(playerSettings, transform);
            
            _inputService.OnGunSwitch += SwitchGun;
            _inputService.OnFire += Fire;
            _inputService.OnGunReload += ReloadGun;
            _inputService.OnRotateLeft += _playerMovement.RotateLeft;
            _inputService.OnRotateRight +=  _playerMovement.RotateRight;
        }

        private void Fire() => 
            _gun.Shoot(transform.forward);

        private void ReloadGun() => 
            _gun.Reload();

        private void SwitchGun() => 
            _gun.ChangeGun();
    }
}