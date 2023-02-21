using Game.CodeBase.Weapon.Bullets;
using UnityEngine;

namespace Game.CodeBase.Weapon.Models
{
    [CreateAssetMenu(fileName = "PhysicBullet", menuName = "Game/PhysicBullet")]
    public class PhysicBullet: BulletModel
    {
        [SerializeField] private BulletFactory _bulletFactory;

        public override void Shoot(Vector3 startPosition, Vector3 direction)
        {
            var bullet = _bulletFactory.CreateBullet(startPosition, direction);
            bullet.MoveForward();
        }
    }
}