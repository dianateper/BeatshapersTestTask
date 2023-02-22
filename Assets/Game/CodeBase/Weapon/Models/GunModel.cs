using System;
using UnityEngine;

namespace Game.CodeBase.Weapon.Models
{
    public enum GunId
    {
        BFG,
        Shotgun,
        DualBarrelShotgun
    }
    
    [CreateAssetMenu(fileName = "Gun", menuName = "Game/Gun")]
    public class GunModel : ScriptableObject
    {
        [SerializeField] private GunId _gunId;
        [SerializeField] private Sprite _gunSprite;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private BulletModel bulletModel;
        [SerializeField] private int _maxAmmo;
        [SerializeField] private int _bulletCountPerShoot;
        [SerializeField] private float _reloadTime;
        [SerializeField] private float _coolDownTime;
        
        private int _currentAmmo;
        
        public int MaxAmmo => _maxAmmo;
        public float ReloadTime => _reloadTime;
        public float CoolDownTime => _coolDownTime;
        public Sprite Sprite => _gunSprite;
        public AudioClip AudioClip => _audioClip;
        
        public int CurrentAmmo
        {
            get => _currentAmmo;
            set
            {
                if (_currentAmmo == value) 
                    return;
                
                if (value < 0) 
                    _currentAmmo = 0;
                
                _currentAmmo = value;
                OnGunInfoChange?.Invoke();
            }
        }

        public event Action OnGunInfoChange;

        public void Construct()
        {
            CurrentAmmo = _maxAmmo;
        }

        public bool TryShoot(Vector3 startPosition, Vector3 direction)
        {
            if (_currentAmmo - _bulletCountPerShoot >= 0)
            {
                bulletModel.Shoot(_bulletCountPerShoot, startPosition, direction);
                CurrentAmmo -= _bulletCountPerShoot;
                return true;
            }

            return false;
        }
    }
}