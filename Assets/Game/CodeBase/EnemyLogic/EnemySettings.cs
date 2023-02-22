using System;
using UnityEngine;

namespace Game.CodeBase.EnemyLogic
{
    [Serializable]
    public class EnemySettings
    {
        [SerializeField] private float _enemySpawnRadius;
        [SerializeField] private float _enemySpeed;
        [SerializeField] private float _damage;
        [SerializeField] private float _offsetY;
        
        public float EnemySpawnRadius => _enemySpawnRadius;
        public float OffsetY => _offsetY;
        public float EnemySpeed => _enemySpeed;
        public float Damage => _damage;
    }
}