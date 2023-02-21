using Game.CodeBase.Common;
using UnityEngine;

namespace Game.CodeBase.Weapon.Models
{
    [CreateAssetMenu(fileName = "LaserBullet", menuName = "Game/LaserBullet")]
    public class LaserBullet: BulletModel
    {
        [SerializeField] private float _lasetDistance;
        private RaycastHit _hit;

        public override void Shoot(Vector3 startPosition, Vector3 direction)
        {
            if (Physics.Raycast(startPosition, direction, out _hit, _lasetDistance))
            {
                if (_hit.collider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(_damage);
                }
            }
        }
    }
}