using System;

namespace Game.CodeBase.Common
{
    public interface IHealth : IDamageable
    {
        float CurrentHealth { get; }

        event Action OnCurrentHealthChange;

        event Action OnDie;

        void ResetHealth(float maxHealth);
    }
}