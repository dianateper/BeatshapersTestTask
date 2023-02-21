using System.Collections.Generic;
using Game.CodeBase.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.CodeBase.EnemyLogic
{
    [CreateAssetMenu(fileName = "EnemyFactory", menuName = "Game/EnemyFactory")]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private EnemySettings _enemySettings;
        private ObjectPool<Enemy> _enemies;

        public EnemyFactory()
        {
            _enemies = new ObjectPool<Enemy>();
        }
        
        public Enemy CreateEnemy(Transform target)
        {
            var enemy = _enemies.GetFromPool();
            if (enemy == null)
            {
                enemy = Instantiate(_enemyPrefab);
            }

            enemy.transform.SetPositionAndRotation(GetRandomPosition(_enemySettings.EnemySpawnRadius),
                Quaternion.identity);
            enemy.Construct(target, _enemySettings);   
            return enemy;
        }

        public void Reclaim(Enemy enemy)
        {
            _enemies.ReturnToPool(enemy);
        }

        private Vector3 GetRandomPosition(float radius)
        {
            var position = Random.onUnitSphere * radius;
            position.y = -1;
            return position;
        }

        public void ReclaimAll(List<Enemy> activeEnemies)
        {
            foreach (var enemy in activeEnemies)
            {
                Reclaim(enemy);
            }
        }
    }
}