using System;
using Game.CodeBase.Common;
using Game.CodeBase.Core.Services;
using Game.CodeBase.Weapon.Guns;

namespace Game.CodeBase.PlayerLogic
{
    public interface IPlayer
    {
        public IInputService InputService { get; set; }
        public IHealth PlayerHealth { get; }
        public IGun Gun { get; }
    }
}