using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.CodeBase.EnemyLogic
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private float _spawnDelayInSeconds;

        private Transform _target;
        private WaitForSeconds _spawnDelay;
        private List<Enemy> _activeEnemies;
        
        public void Construct(Transform playerBaseTransform)
        {
            _activeEnemies = new List<Enemy>();
            _target = playerBaseTransform;
            _spawnDelay = new WaitForSeconds(_spawnDelayInSeconds);
        }

        public void StartSpawning()
        {
            StartCoroutine(CreateEnemy());
        }

        public void StopSpawning()
        {
            StopCoroutine(CreateEnemy());
            _enemyFactory.ReclaimAll(_activeEnemies);
        }

        private IEnumerator CreateEnemy()
        {
            while (true)
            {
                var enemy = _enemyFactory.CreateEnemy(_target);
                _activeEnemies.Add(enemy);
                enemy.OnReclaim += Reclaim;
                yield return _spawnDelay;
            }
        }

        private void Reclaim(Enemy enemy)
        {
            _activeEnemies.Remove(enemy);
            _enemyFactory.Reclaim(enemy);
        }
    }
}