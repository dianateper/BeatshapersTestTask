using System;
using UnityEngine;

namespace Game.CodeBase.PlayerLogic
{
    [Serializable]
    public class PlayerMovementSettings
    {
        [SerializeField] private float _rotationSpeed = 10;
      
        public float RotationSpeed => _rotationSpeed;
    }
}