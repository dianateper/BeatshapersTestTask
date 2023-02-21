using System;
using UnityEngine;

namespace Game.CodeBase.Weapon.Models
{
    [Serializable]
    public abstract class BulletModel : ScriptableObject
    {
        public abstract void Shoot(int bulletCount, Vector3 startPosition, Vector3 direction);
    }
}