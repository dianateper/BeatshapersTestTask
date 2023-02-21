using System;
using Game.CodeBase.Common;
using UnityEngine;

namespace Game.CodeBase.PlayerLogic
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        private float _currentHealth;
        public float MaxHealth { get; set; }
        public float CurrentHealth => _currentHealth;
        public event Action OnCurrentHealthChange;
        public event Action OnDie;
        
        public void ResetHealth(float maxHealth)
        {
            _currentHealth = maxHealth;
            MaxHealth = maxHealth;
            OnCurrentHealthChange?.Invoke();
        }
        
        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            OnCurrentHealthChange?.Invoke();
            if (CurrentHealth <= 0)
            {
                OnDie?.Invoke();
                _currentHealth = 0;
            }
        }
    }
}