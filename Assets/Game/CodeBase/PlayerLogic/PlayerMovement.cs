using UnityEngine;

namespace Game.CodeBase.PlayerLogic
{
    public class PlayerMovement
    {
        private readonly Transform _transform;
        private readonly float _rotationSpeed;

        public PlayerMovement(PlayerSettings playerSettings, Transform transform)
        {
            _transform = transform;
            _rotationSpeed = playerSettings.RotationSpeed;
        }

        public void RotateLeft() =>
            _transform.Rotate(_transform.up, -Time.deltaTime * _rotationSpeed);

        public void RotateRight() =>
            _transform.Rotate(_transform.up, Time.deltaTime * _rotationSpeed);
    }
}