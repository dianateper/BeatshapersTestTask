using System.Collections;
using Game.CodeBase.PlayerLogic;
using UnityEngine;

namespace Game.CodeBase.EnemyLogic
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private float _spawnDelayInSeconds;

        private Transform _target;
        private WaitForSeconds _spawnDelay;
        private bool _isSpawning;

        private void Start()
        {
            _target = FindObjectOfType<PlayerBase>().transform;
            _spawnDelay = new WaitForSeconds(_spawnDelayInSeconds);
            StartSpawning();
        }

        private void StartSpawning()
        {
            _isSpawning = true;
            StartCoroutine(CreateEnemy());
        }

        private void StopSpawning()
        {
            StopCoroutine(CreateEnemy());
        }

        private IEnumerator CreateEnemy()
        {
            while (_isSpawning)
            {
                _enemyFactory.CreateEnemy(_target);
                yield return _spawnDelay;
            }
        }
    }
}