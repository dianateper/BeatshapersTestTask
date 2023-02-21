using System;
using UnityEngine;

namespace Game.CodeBase.PlayerLogic
{
    [Serializable]
    public class PlayerSettings
    {
        [SerializeField] private float _rotationSpeed = 10;
        [SerializeField] private float _maxHealth = 10;
      
        public float RotationSpeed => _rotationSpeed;
        public float MaxHealth => _maxHealth;
    }
}