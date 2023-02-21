using Game.CodeBase.Common;
using UnityEngine;

namespace Game.CodeBase.Weapon.Bullets
{
    [CreateAssetMenu(fileName = "BulletFactory", menuName = "Game/BulletFactory")]
    public class BulletFactory : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        [SerializeField] private Bullet _bullet;
        private ObjectPool<Bullet> _bullets;

        public BulletFactory()
        {
            _bullets = new ObjectPool<Bullet>();
        }
        
        public void Reclaim(Bullet bullet) => 
            _bullets.ReturnToPool(bullet);

        public Bullet CreateBullet(Vector3 at, Vector3 direction)
        {
            var bullet = _bullets.GetFromPool();
            
            if (bullet == null)
            {
                bullet = Instantiate(_bullet);       
            }

            bullet.transform.position = at;
            bullet.transform.forward = direction;
            bullet.Construct(this, _lifeTime, _speed);
            return bullet;
        }
    }
}