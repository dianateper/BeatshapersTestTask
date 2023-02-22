using Game.CodeBase.EnemyLogic;
using Game.CodeBase.PlayerLogic;
using Game.CodeBase.UI;
using UnityEngine;

namespace Game.CodeBase.Core
{
    public class LevelContext : MonoBehaviour
    {
        [SerializeField] private PlayerBase _playerBase;
        [SerializeField] private PlayerHud _playerHud;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private GameOverWindow _gameOverWindowPrefab;
     
        private GameOverWindow _gameOverWindow;
        
        private void Awake()
        {
            LoadGame();
        }

        private void LoadGame()
        {
            _playerBase.Initialize();
            _playerBase.EnableInput();
           
            _playerHud.Construct(_playerBase.PlayerHealth, _playerBase.Gun);
            _enemySpawner.Construct(_playerBase.transform);
            _enemySpawner.StartSpawning();

            _playerBase.PlayerHealth.OnDie += EndGame;
        }

        private void EndGame()
        {
            _enemySpawner.StopSpawning();
            _playerBase.DeInitialize();
            _playerBase.DisableInput();
            _playerHud.DeInitialize();

            _playerBase.PlayerHealth.OnDie -= EndGame;
            _gameOverWindow = Instantiate(_gameOverWindowPrefab);
            _gameOverWindow.OnReloadClick += LoadGame;
        }
    }
}