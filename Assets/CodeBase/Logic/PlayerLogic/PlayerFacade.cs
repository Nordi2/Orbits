using System;
using UnityEngine;

namespace CodeBase.Logic.PlayerLogic
{
    public class PlayerFacade : MonoBehaviour, IPlayerFacade
    {
        private DeathObserver _deathObserver;
        public event Action DiePlayer;

        private void Awake() =>
            _deathObserver = GetComponentInChildren<DeathObserver>();

        private void OnEnable() =>
            _deathObserver.TriggerEnter += Death;

        private void OnDisable() =>
            _deathObserver.TriggerEnter -= Death;

        private void Death()
        {
            DiePlayer?.Invoke();
            Destroy(gameObject);
        }

        public void StopAction() =>
            GetComponentInChildren<PlayerMovement>().enabled = false;

        public void StartAction() =>
            GetComponentInChildren<PlayerMovement>().enabled = true;
    }
}