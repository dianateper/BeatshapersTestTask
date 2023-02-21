using System;
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
      [SerializeField] private GunRenderer _gunRenderer;
      
      private int _currentGunIndex;
      public int CurrentAmmo => _currentGun.CurrentAmmo;
      public event Action<IGunView> OnGunInfoChange;

      public void Initialize()
      {
         foreach (var gun in _guns)
         {
            gun.OnGunInfoChange += UpdateGunInfo;
            gun.Construct(this);
         }

         _currentGun = _guns[0];
         UpdateGunRenderer();
      }

      public void DeInitialize()
      {
         foreach (var gun in _guns)
         {
            gun.OnGunInfoChange -= UpdateGunInfo;
         }
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
         UpdateGunRenderer();
         UpdateGunInfo();
      }

      private void UpdateGunRenderer()
      {
         _gunRenderer.ChangeSprite(_currentGun);
      }

      private void UpdateGunInfo() => OnGunInfoChange?.Invoke(this);
   }
}