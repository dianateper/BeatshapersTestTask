using Game.CodeBase.Weapon.Bullets;
using UnityEngine;

namespace Game.CodeBase.Weapon.Models
{
    [CreateAssetMenu(fileName = "PhysicBullet", menuName = "Game/PhysicBullet")]
    public class PhysicBullet: BulletModel
    {
        [SerializeField] private BulletFactory _bulletFactory;

        public override void Shoot(int bulletCount, Vector3 startPosition, Vector3 direction)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                var bullet = _bulletFactory.CreateBullet( startPosition, direction);
                bullet.MoveForward();   
            }
        }
    }
}