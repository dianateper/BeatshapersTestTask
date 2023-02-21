using UnityEngine;

namespace Game.CodeBase.EnemyLogic
{
    public class Enemy : MonoBehaviour
    {
        private Transform _target;
        private Vector3 _direction;
        private float _speed;

        public void Construct(Transform target, float speed)
        {
            _target = target;
            _speed = speed;
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
            
        }
    }
}