using System;
using Game.CodeBase.Common.HealthSystem;
using Game.CodeBase.Weapon.Bullets;
using UnityEngine;

namespace Game.CodeBase.EnemyLogic
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        private Transform _target;
        private Vector3 _direction;
        private float _speed;
        private float _damage;

        public event Action<Enemy> OnReclaim;
        
        public void Construct(Transform target, EnemySettings settings)
        {
            _target = target;
            _speed = settings.EnemySpeed;
            _damage = settings.Damage;
        }

        private void Update()
        {
            if (_target == null) return;

            _direction = _target.transform.position - transform.position;
            _direction.Normalize();
            transform.position += _direction * (Time.deltaTime * _speed);
            transform.LookAt(_target);
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

        public void TakeDamage(float damage)
        {
            OnReclaim?.Invoke(this);
        }
    }
}