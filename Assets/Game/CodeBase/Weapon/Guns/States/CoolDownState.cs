using System.Collections;
using Game.CodeBase.Common.States;
using Game.CodeBase.Weapon.Models;
using UnityEngine;

namespace Game.CodeBase.Weapon.Guns.States
{
    public class CoolDownState : IGunState
    {
        private readonly MonoBehaviour _monoBehaviour;
        private readonly IStateSwitcher _stateSwitcher;
        private WaitForSeconds _coolDownDelay;

        public CoolDownState(MonoBehaviour monoBehaviour, IStateSwitcher stateSwitcher)
        {
            _monoBehaviour = monoBehaviour;
            _stateSwitcher = stateSwitcher;
        }
        
        public void Enter(GunModel payloadData)
        {
            _coolDownDelay = new WaitForSeconds(payloadData.CoolDownTime);
            _monoBehaviour.StartCoroutine(StartCoolDownCoroutine());
        }

        public void Exit()
        {
           
        }
        
        private IEnumerator StartCoolDownCoroutine()
        {
            yield return _coolDownDelay;
            _stateSwitcher.SwitchState<IdleState>();
        }
    }
}