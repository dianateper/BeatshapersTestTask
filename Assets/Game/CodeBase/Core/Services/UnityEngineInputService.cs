using System;
using UnityEngine;

namespace Game.CodeBase.Core.Services
{
    public class UnityEngineInputService : MonoBehaviour, IInputService
    {
        public event Action OnGunSwitch;
        public event Action OnGunReload;
        public event Action OnFire;
        public event Action OnRotateLeft;
        public event Action OnRotateRight;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                OnGunSwitch?.Invoke();
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                OnGunReload?.Invoke();
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                OnRotateLeft?.Invoke();
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                OnRotateRight?.Invoke();
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                OnFire?.Invoke();
            }
        }
    }
}
