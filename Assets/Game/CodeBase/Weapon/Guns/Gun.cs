using System;
using System.Collections.Generic;
using System.Linq;
using Game.CodeBase.Common.States;
using Game.CodeBase.Weapon.Guns.States;
using Game.CodeBase.Weapon.Models;
using UnityEngine;

namespace Game.CodeBase.Weapon.Guns
{
   [RequireComponent(typeof(IGunRenderer))]
   public class Gun : MonoBehaviour, IGun, IStateSwitcher
   {
      [SerializeField] private List<GunModel> _guns;
      [SerializeField] private Transform _shootPosition;

      private GunModel _currentGun;
      private IGunRenderer _gunRenderer;
      private List<IGunState> _states;
      private IGunState _current;
      private int _currentGunIndex;
      
      public int CurrentAmmo => _currentGun.CurrentAmmo;
      public event Action<IGunView> OnGunInfoChange;
      public event Action<GunModel> OnShoot;

      public void Initialize()
      {
         _gunRenderer = GetComponent<IGunRenderer>();
         _states = new List<IGunState>
         {
            new IdleState(),
            new ReloadState(this, this),
            new CoolDownState(this, this)
         };
         
         foreach (var gun in _guns)
         {
            gun.OnGunInfoChange += UpdateGunInfo;
            gun.Construct();
         }
         
         _currentGun = _guns[0];
         SwitchState<IdleState>();
         UpdateGunRenderer();
      }

      public void DeInitialize()
      {
         foreach (var gun in _guns)
         {
            gun.OnGunInfoChange -= UpdateGunInfo;
         }
      }

      public void SwitchState<T>()
      {
         _current?.Exit();
         _current = _states.FirstOrDefault(t => typeof(T) == t.GetType());
         _current?.Enter(_currentGun);
      }

      public void Shoot(Vector3 direction)
      {
         if (_current.GetType() != typeof(IdleState)) 
            return;

         if (_currentGun.TryShoot(_shootPosition.position, direction))
         {
            OnShoot?.Invoke(_currentGun);  
            SwitchState<CoolDownState>();
         }
      }

      public void Reload()
      {
         if (_current.GetType() != typeof(IdleState))
            return;
         
         SwitchState<ReloadState>();
      }

      public void ChangeGun()
      {
         ChangeGunModel();
         UpdateGunRenderer();
         UpdateGunInfo();
      }

      private void ChangeGunModel()
      {
         _currentGunIndex = (_currentGunIndex + 1) % _guns.Count;
         _currentGun = _guns[_currentGunIndex];
      }

      private void UpdateGunRenderer() => _gunRenderer.UpdateGunRenderer(_currentGun);

      private void UpdateGunInfo() => OnGunInfoChange?.Invoke(this);
   }
}