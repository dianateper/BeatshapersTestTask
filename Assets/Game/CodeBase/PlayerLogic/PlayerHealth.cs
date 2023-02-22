using System;
using Game.CodeBase.Common.HealthSystem;
using UnityEngine;

namespace Game.CodeBase.PlayerLogic
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        private float _currentHealth;
        public float CurrentHealth => _currentHealth;
        public event Action OnCurrentHealthChange;
        public event Action OnDie;
        
        public void ResetHealth(float maxHealth)
        {
            _currentHealth = maxHealth;
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