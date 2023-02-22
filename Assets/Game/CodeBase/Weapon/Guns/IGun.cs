using System;
using Game.CodeBase.Weapon.Models;
using UnityEngine;

namespace Game.CodeBase.Weapon.Guns
{
    public interface IGun : IGunView
    {
        public event Action<GunModel> OnShoot;
        void Initialize();
        void DeInitialize();
        void Shoot(Vector3 direction);
        void Reload();
        void ChangeGun();
    }
}