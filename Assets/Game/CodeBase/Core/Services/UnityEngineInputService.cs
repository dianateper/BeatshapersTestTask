using System;
using UnityEngine;

namespace Game.CodeBase.Core.Services
{
    public class UnityEngineInputService : MonoBehaviour, IInputService
    {
        private const float MouseSensitivity = 1;
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
        
        public event Action OnGunSwitch;
        public event Action OnGunReload;
        public event Action OnFire;
        public event Action OnRotateLeft;
        public event Action OnRotateRight;

        public float GetMouseHorizontalInput() => 
            Input.GetAxis(MouseX) * MouseSensitivity;

        public float GetMouseVerticalInput() => 
            Input.GetAxis(MouseY) * MouseSensitivity;

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
