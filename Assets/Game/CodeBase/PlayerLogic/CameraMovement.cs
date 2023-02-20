using Game.CodeBase.Core.Services;
using UnityEngine;

namespace Game.CodeBase.PlayerLogic
{
   public class CameraMovement : MonoBehaviour
   {
      private IInputService _inputService;
      private readonly float _minimumX = -90f;
      private readonly float _maximumX = 90f;
      private float _rotationX;

      public void Construct(IInputService inputService)
      {
         _inputService = inputService;
      }
      
      private void Update()
      {
         float rotateHorizontal = _inputService.GetMouseHorizontalInput();

         _rotationX += _inputService.GetMouseVerticalInput();
         _rotationX = Mathf.Clamp(_rotationX, _minimumX, _maximumX);

         transform.Rotate(0, rotateHorizontal, 0);
         transform.localEulerAngles = new Vector3(-_rotationX, transform.localEulerAngles.y, 0);
      }
   }
}
