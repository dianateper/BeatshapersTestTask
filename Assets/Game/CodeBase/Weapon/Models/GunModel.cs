using System.Collections;
using UnityEngine;

namespace Game.CodeBase.Weapon.Models
{
    public enum GunId
    {
        BFG,
        Shotgun,
        Dual
    }
    
    [CreateAssetMenu(fileName = "Gun", menuName = "Game/Gun")]
    public class GunModel : ScriptableObject
    {
        [SerializeField] private GunId _gunId;
        [SerializeField] private Sprite _gunSprite;
        [SerializeField] private int _maxAmmo;
        [SerializeField] private BulletModel bulletModel;
        [SerializeField] protected int _ammoPerShoot;
        [SerializeField] private float _coolDownTime;
        [SerializeField] private float _reloadTime;

        private bool _canShoot = true;
        private int _currentAmmo;
        private MonoBehaviour _monoBehaviour;
        private WaitForSeconds _coolDownDelay;
        private WaitForSeconds _reloadDelay;

        public Sprite Sprite => _gunSprite;

        private void OnEnable()
        {
            _currentAmmo = _maxAmmo;
            _canShoot = true;
        }

        public void Construct(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
            _coolDownDelay = new WaitForSeconds(_coolDownTime);
            _reloadDelay = new WaitForSeconds(_reloadTime);
        }

        public void Shoot(Vector3 startPosition, Vector3 direction)
        {
            if (_canShoot && _currentAmmo - _ammoPerShoot >= 0)
            {
                _canShoot = false;
                bulletModel.Shoot(startPosition, direction);
                _currentAmmo -= _ammoPerShoot;
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
            _currentAmmo = _maxAmmo;
            yield return _reloadDelay;
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