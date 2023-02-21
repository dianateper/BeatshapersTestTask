using System.Collections.Generic;
using Game.CodeBase.Weapon.Models;
using UnityEngine;

namespace Game.CodeBase.Weapon.Guns
{
   public class Gun : MonoBehaviour, IGun
   {
      [SerializeField] private List<GunModel> _guns;
      [SerializeField] private GunModel _currentGun;
      [SerializeField] private Transform _shootPosition;
      [SerializeField] private GunView _gunView;
      
      private int _currentGunIndex;
      
      private void Start()
      {
         foreach (var gun in _guns) 
            gun.Construct(this);
         _currentGun = _guns[0];
      }

      public void Shoot(Vector3 direction) => 
         _currentGun.Shoot(_shootPosition.position, direction);

      public void Reload() => 
         _currentGun.ReloadAmmo();
      
      public void ChangeGun()
      {
         _currentGun.StopReloading();
         _currentGunIndex = (_currentGunIndex + 1) % _guns.Count;
         _currentGun = _guns[_currentGunIndex];
         _gunView.ChangeSprite(_currentGun);
      }
   }
}