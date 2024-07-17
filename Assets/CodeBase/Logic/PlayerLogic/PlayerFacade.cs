using System;
using Unity.Mathematics;
using UnityEngine;

namespace CodeBase.Logic.PlayerLogic
{
    public class PlayerFacade : MonoBehaviour, IPlayerFacade
    {
        [SerializeField] private ParticleSystem _explosionParticle;

        private Transform _spawnPointParticle;
        private DeathObserver _deathObserver;
        public event Action DiePlayer;

        private void Awake()
        {
            _spawnPointParticle = GetComponentInChildren<PlayerMovement>().transform;
            _deathObserver = GetComponentInChildren<DeathObserver>();
        }

        private void OnEnable() =>
            _deathObserver.TriggerEnter += Death;

        private void OnDisable() =>
            _deathObserver.TriggerEnter -= Death;

        public void StartAction() =>
            GetComponentInChildren<PlayerMovement>().enabled = true;

        public void StopAction() =>
            GetComponentInChildren<PlayerMovement>().enabled = false;

        private void Death()
        {
            DiePlayer?.Invoke();
            Instantiate(_explosionParticle, _spawnPointParticle.transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }
}