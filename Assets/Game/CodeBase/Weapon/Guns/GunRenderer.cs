using Game.CodeBase.Weapon.Models;
using UnityEngine;

namespace Game.CodeBase.Weapon.Guns
{
    public class GunRenderer : MonoBehaviour, IGunRenderer
    {
        [SerializeField] private SpriteRenderer _gunRenderer;

        public void UpdateGunRenderer(GunModel gunModel)
        {
            _gunRenderer.sprite = gunModel.Sprite;
        }
    }
}