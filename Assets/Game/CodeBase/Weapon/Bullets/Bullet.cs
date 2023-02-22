using System.Collections;
using Game.CodeBase.EnemyLogic;
using UnityEngine;

namespace Game.CodeBase.Weapon.Bullets
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour, IBullet
    {
        private Rigidbody _rigidbody;
        private BulletFactory _bulletFactory;
        private WaitForSeconds _returnToPoolDelay;
        private float _speed;

        public void Construct(BulletFactory bulletFactory, float lifeTime, float speed)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _bulletFactory = bulletFactory;
            _speed = speed;
            _returnToPoolDelay = new WaitForSeconds(lifeTime);
            StartCoroutine(ReclaimBullet());
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IEnemy _))
            {
                _bulletFactory.Reclaim(this);
            }
        }

        public void MoveForward()
        {
            _rigidbody.velocity = transform.forward * _speed;
        }

        private IEnumerator ReclaimBullet()
        {
            yield return _returnToPoolDelay;
            _bulletFactory.Reclaim(this);
        }
    }
}