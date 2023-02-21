using Game.CodeBase.Common;
using Game.CodeBase.Core.Services;
using Game.CodeBase.Weapon;
using Game.CodeBase.Weapon.Guns;
using UnityEngine;

namespace Game.CodeBase.PlayerLogic
{
    public class PlayerBase : MonoBehaviour, IPlayer
    {
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;
       
        private PlayerMovement _playerMovement;
        private IInputService _inputService;
        private IGun _gun;
        
        private void Awake()
        {
            _inputService = GetComponent<IInputService>();
            _gun = GetComponentInChildren<IGun>();
            
            _playerMovement = new PlayerMovement(_playerMovementSettings, transform);
            
            _inputService.OnGunSwitch += SwitchGun;
            _inputService.OnFire += Fire;
            _inputService.OnGunReload += ReloadGun;
            _inputService.OnRotateLeft += _playerMovement.RotateLeft;
            _inputService.OnRotateRight +=  _playerMovement.RotateRight;
        }

        private void Fire()
        {
            _gun.Shoot(transform.forward);
        }

        private void ReloadGun()
        {
            _gun.Reload();
        }

        private void SwitchGun()
        {
            _gun.ChangeGun();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable _))
            {
                Debug.Log("Player hit");   
            }
        }
    }
}