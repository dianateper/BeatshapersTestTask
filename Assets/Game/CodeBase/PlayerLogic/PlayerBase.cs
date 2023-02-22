using Game.CodeBase.Common.Audio;
using Game.CodeBase.Common.HealthSystem;
using Game.CodeBase.Core.Services;
using Game.CodeBase.Weapon.Guns;
using Game.CodeBase.Weapon.Models;
using UnityEngine;

namespace Game.CodeBase.PlayerLogic
{
    [RequireComponent(typeof(IHealth))]
    [RequireComponent(typeof(IInputService))]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerBase : MonoBehaviour, IPlayer
    {
        [SerializeField] private PlayerSettings _playerSettings;
        private AudioSource _audioSource;
        private PlayerMovement _playerMovement;

        private IInputService _inputService;
        private IAudioHandler _audioHandler;
        private IHealth _playerHealth;
        private IGun _gun;

        public IInputService InputService { get; set; }
        public IHealth PlayerHealth => _playerHealth;
        public IGun Gun => _gun;
        
        public void Initialize()
        {
            _playerHealth = GetComponent<IHealth>();
            _playerHealth.ResetHealth(_playerSettings.MaxHealth);
            
            _audioSource = GetComponent<AudioSource>();
            _audioHandler = new AudioHandler(_audioSource);
            
            _gun = GetComponentInChildren<IGun>();
            _gun.Initialize();
            _gun.OnShoot += PlayAudioClip;
            
            _playerMovement = new PlayerMovement(_playerSettings, transform);
        }

        public void DeInitialize()
        {
            _gun.OnShoot -= PlayAudioClip;
            _gun.DeInitialize();
        }

        public void DisableInput()
        {
            if (_inputService == null) return;
            _inputService.OnGunSwitch -= SwitchGun;
            _inputService.OnFire -= Fire;
            _inputService.OnGunReload -= ReloadGun;
            _inputService.OnRotateLeft -= _playerMovement.RotateLeft;
            _inputService.OnRotateRight -=  _playerMovement.RotateRight;
        }

        public void EnableInput()
        {
            _inputService = GetComponent<IInputService>();
            _inputService.OnGunSwitch += SwitchGun;
            _inputService.OnFire += Fire;
            _inputService.OnGunReload += ReloadGun;
            _inputService.OnRotateLeft += _playerMovement.RotateLeft;
            _inputService.OnRotateRight +=  _playerMovement.RotateRight;
        }

        private void PlayAudioClip(GunModel gun) => 
            _audioHandler.PlayAudioClip(gun.AudioClip);

        private void Fire() => 
            _gun.Shoot(transform.forward);

        private void ReloadGun() => 
            _gun.Reload();

        private void SwitchGun() => 
            _gun.ChangeGun();
    }
}