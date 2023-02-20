using System;

namespace Game.CodeBase.Core.Services
{
    public interface IInputService
    {
        event Action OnGunSwitch;
        event Action OnGunReload;
        event Action OnFire;
        event Action OnRotateLeft;
        event Action OnRotateRight;
        
        float GetMouseHorizontalInput();
        float GetMouseVerticalInput();
    }
}