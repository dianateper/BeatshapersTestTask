using System;
using UnityEngine;

namespace Game.CodeBase.EnemyLogic
{
    [Serializable]
    public class EnemySettings
    {
        [SerializeField] private float _enemySpawnRadius;
        [SerializeField] private float _enemySpeed;
        
        public float EnemySpawnRadius => _enemySpawnRadius;
        public float EnemySpeed => _enemySpeed;
    }
}