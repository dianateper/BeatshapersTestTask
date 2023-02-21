using System;

namespace Game.CodeBase.Common
{
    public interface IHealth : IDamageable
    {
        float MaxHealth { get; set; }
        float CurrentHealth { get; }

        event Action<float> OnCurrentHealthChange;

        event Action OnDie;
    }
}