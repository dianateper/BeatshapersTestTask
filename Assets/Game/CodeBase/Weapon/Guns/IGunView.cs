using System;

namespace Game.CodeBase.Weapon.Guns
{
    public interface IGunView
    {
        int CurrentAmmo { get; }
        event Action<IGunView> OnGunInfoChange;
    }
}