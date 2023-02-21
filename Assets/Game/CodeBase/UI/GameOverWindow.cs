using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.CodeBase.UI
{
    public class GameOverWindow : MonoBehaviour
    {
        [SerializeField] private Button _reloadGame;

        public event Action OnReloadClick;
        
        private void OnEnable() => _reloadGame.onClick.AddListener(ReloadGame);

        private void ReloadGame()
        {
            OnReloadClick?.Invoke();
            Destroy(gameObject);
        }
    }
}