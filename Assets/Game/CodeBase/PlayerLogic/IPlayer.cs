using Game.CodeBase.Common.HealthSystem;
using Game.CodeBase.Core.Services;
using Game.CodeBase.Weapon.Guns;

namespace Game.CodeBase.PlayerLogic
{
    public interface IPlayer
    {
        public IInputService InputService { get; }
        public IHealth PlayerHealth { get; }
        public IGun Gun { get; }

        public void DisableInput();
        public void EnableInput();
    }
}