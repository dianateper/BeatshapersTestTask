using Game.CodeBase.Weapon.Models;
using UnityEngine;

namespace Game.CodeBase.Weapon.Guns
{
    public class GunRenderer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _gunRenderer;

        public void ChangeSprite(GunModel gunsModel)
        {
            _gunRenderer.sprite = gunsModel.Sprite;
        }
    }
}