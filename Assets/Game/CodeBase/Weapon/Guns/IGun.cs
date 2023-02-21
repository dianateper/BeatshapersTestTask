using UnityEngine;

namespace Game.CodeBase.Weapon.Guns
{
    public interface IGun : IGunView
    {
        void Initialize();
        void DeInitialize();
        void Shoot(Vector3 direction);
        void Reload();
        void ChangeGun();
    }
}