using System;
using UnityEngine;

namespace Game.CodeBase.Weapon.Models
{
    [Serializable]
    public abstract class BulletModel : ScriptableObject
    {
        [SerializeField] protected int _damage;
        public float Damage => _damage;

        public abstract void Shoot(Vector3 startPosition, Vector3 direction);
    }
}