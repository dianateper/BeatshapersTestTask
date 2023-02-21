using System;
using Game.CodeBase.Common;
using Game.CodeBase.Weapon.Bullets;
using UnityEngine;

namespace Game.CodeBase.EnemyLogic
{
    public class Enemy : MonoBehaviour, IDamageable, IEnemy
    {
        private Transform _target;
        private Vector3 _direction;
        private float _speed;
        private float _damage;

        public event Action<Enemy> OnReclaim;
        
        public void Construct(Transform target, float speed)
        {
            _target = target;
            _speed = speed;
            _damage = 1;
        }

        private void Update()
        {
            if (_target == null) return;

            _direction = _target.transform.position - transform.position;
            _direction.Normalize();
            transform.position += _direction * (Time.deltaTime * _speed);
            transform.LookAt(_target);
        }

        public void TakeDamage(float damage)
        {
            OnReclaim?.Invoke(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
                OnReclaim?.Invoke(this);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IBullet _))
            {
                OnReclaim?.Invoke(this);
            }
        }
    }
}