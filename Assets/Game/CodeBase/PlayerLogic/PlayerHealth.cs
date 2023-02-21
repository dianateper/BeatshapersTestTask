using System;
using Game.CodeBase.Common;
using UnityEngine;

namespace Game.CodeBase.PlayerLogic
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }
        public event Action<float> OnCurrentHealthChange;
        public event Action OnDie;

        public void Construct(PlayerSettings playerSettings)
        {
            MaxHealth = playerSettings.MaxHealth;
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            OnCurrentHealthChange?.Invoke(CurrentHealth);
            if (CurrentHealth <= 0)
            {
                OnDie?.Invoke();
                CurrentHealth = 0;
            }
        }
    }
}