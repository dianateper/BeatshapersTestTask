using Game.CodeBase.Weapon.Models;
using UnityEngine;

namespace Game.CodeBase.Weapon.Guns
{
    public class GunView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _gunRenderer;

        public void ChangeSprite(GunModel gunModel)
        {
            _gunRenderer.sprite = gunModel.Sprite;
        }
    }
}