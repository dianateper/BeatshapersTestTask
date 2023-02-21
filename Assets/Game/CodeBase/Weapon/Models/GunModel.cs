using System;
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
        [SerializeField] private float _coolDown;
        [SerializeField] private BulletModel bulletModel;
        [SerializeField] protected int _ammoPerShoot;

        private bool _canShoot = true;
        private int _currentAmmo;
     
        public Sprite Sprite => _gunSprite;

        private void OnEnable()
        {
            _currentAmmo = _maxAmmo;
            _canShoot = true;
        }

        public void Shoot(Vector3 startPosition, Vector3 direction, MonoBehaviour monoBehaviour)
        {
            if (_canShoot && _currentAmmo - _ammoPerShoot >= 0)
            {
                _canShoot = false;
                bulletModel.Shoot(startPosition, direction);
                _currentAmmo -= _ammoPerShoot;
                monoBehaviour.StartCoroutine(StartCoolDown());
            }
        }

        public void ReloadAmmo() => 
            _currentAmmo = _maxAmmo;

        private IEnumerator StartCoolDown()
        {
            yield return new WaitForSeconds(_coolDown);
            _canShoot = true;
        }
    }
}