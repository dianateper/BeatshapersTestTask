using System;
using System.Collections;
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
        [SerializeField] private int _maxAmmo;
        [SerializeField] private BulletModel bulletModel;
        [SerializeField] protected int _bulletCountPerShoot;
        [SerializeField] private float _coolDownTime;
        [SerializeField] private float _reloadTime;

        private bool _canShoot = true;
        private int _currentAmmo;
        private MonoBehaviour _monoBehaviour;
        private WaitForSeconds _coolDownDelay;
        private WaitForSeconds _reloadDelay;
        
        public Sprite Sprite => _gunSprite;
        
        public int CurrentAmmo
        {
            get => _currentAmmo;
            private set
            {
                if (value < 0) 
                    _currentAmmo = 0;
                _currentAmmo = value;
                OnGunInfoChange?.Invoke();
            }
        }

        public event Action OnGunInfoChange;

        public void Construct(MonoBehaviour monoBehaviour)
        {
            CurrentAmmo = _maxAmmo;
            _canShoot = true;
            _monoBehaviour = monoBehaviour;
            _coolDownDelay = new WaitForSeconds(_coolDownTime);
            _reloadDelay = new WaitForSeconds(_reloadTime);
        }

        public void Shoot(Vector3 startPosition, Vector3 direction)
        {
            if (_canShoot && _currentAmmo - _bulletCountPerShoot >= 0)
            {
                _canShoot = false;
                bulletModel.Shoot(_bulletCountPerShoot, startPosition, direction);
                CurrentAmmo -= _bulletCountPerShoot;
                _monoBehaviour.StartCoroutine(StartCoolDownCoroutine());
            }
        }

        public void ReloadAmmo()
        {
            _canShoot = false;
            _monoBehaviour.StartCoroutine(ReloadAmmoCoroutine());
        }

        private IEnumerator ReloadAmmoCoroutine()
        {
            yield return _reloadDelay;
            CurrentAmmo = _maxAmmo;
            _canShoot = true;
        }

        private IEnumerator StartCoolDownCoroutine()
        {
            yield return _coolDownDelay;
            _canShoot = true;
        }

        public void StopReloading()
        {
            _canShoot = true;
            _monoBehaviour.StopCoroutine(ReloadAmmoCoroutine());
        }
    }
}