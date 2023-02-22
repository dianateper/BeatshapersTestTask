using System.Collections;
using Game.CodeBase.Common.States;
using Game.CodeBase.Weapon.Models;
using UnityEngine;

namespace Game.CodeBase.Weapon.Guns.States
{
    public class ReloadState : IGunState
    {
        private readonly MonoBehaviour _monoBehaviour;
        private readonly IStateSwitcher _stateSwitcher;
        private WaitForSeconds _reloadDelay;
        private GunModel _currentGun;

        public ReloadState(MonoBehaviour monoBehaviour,  IStateSwitcher stateSwitcher)
        {
            _monoBehaviour = monoBehaviour;
            _stateSwitcher = stateSwitcher;
        }

        public void Enter(GunModel payloadData)
        {
            _reloadDelay = new WaitForSeconds(payloadData.ReloadTime);
            _currentGun = payloadData;
            _monoBehaviour.StartCoroutine(ReloadAmmoCoroutine());
        }

        public void Exit()
        {
            _monoBehaviour.StopCoroutine(ReloadAmmoCoroutine());
        }
        
        private IEnumerator ReloadAmmoCoroutine()
        {
            yield return _reloadDelay;
            _currentGun.CurrentAmmo = _currentGun.MaxAmmo;
            _stateSwitcher.SwitchState<IdleState>();
        }
    }
}