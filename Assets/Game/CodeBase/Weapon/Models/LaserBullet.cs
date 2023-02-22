using Game.CodeBase.Common.HealthSystem;
using UnityEngine;

namespace Game.CodeBase.Weapon.Models
{
    [CreateAssetMenu(fileName = "LaserBullet", menuName = "Game/LaserBullet")]
    public class LaserBullet: BulletModel
    {
        [SerializeField] private float _laserDistance;
        private RaycastHit _hit;

        public override void Shoot(int bulletCount, Vector3 startPosition, Vector3 direction)
        {
            if (Physics.Raycast(startPosition, direction, out _hit, _laserDistance))
            {
                if (_hit.collider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(bulletCount);
                }
            }
        }
    }
}