using Game.CodeBase.Core.Services;
using UnityEngine;

namespace Game.CodeBase.PlayerLogic
{
    public class PlayerBase : MonoBehaviour
    {
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;
       
        private PlayerMovement _playerMovement;
        private IInputService _inputService;
        
        private void Awake()
        {
            _inputService = FindObjectOfType<UnityEngineInputService>();
            _playerMovement = new PlayerMovement(_playerMovementSettings, transform);
            
            _inputService.OnGunSwitch += SwitchGun;
            _inputService.OnFire += Fire;
            _inputService.OnGunReload += ReloadGun;
            _inputService.OnRotateLeft += _playerMovement.RotateLeft;
            _inputService.OnRotateRight +=  _playerMovement.RotateRight;
        }

        private void Fire()
        {
            
        }

        private void ReloadGun()
        {
            
        }

        private void SwitchGun()
        {
            
        }
    }
}