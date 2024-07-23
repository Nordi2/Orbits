using System;
using Unity.Mathematics;
using UnityEngine;

namespace CodeBase.Logic.PlayerLogic
{
    public class PlayerFacade : MonoBehaviour, IPlayerFacade
    {
        [SerializeField] private ParticleSystem _explosionParticle;

        private Transform _spawnPointParticle;
        private PlayerDeathObserver _playerDeathObserver;
        public event Action DiePlayer;

        private void Awake()
        {
            _spawnPointParticle = GetComponentInChildren<PlayerMovement>().transform;
            _playerDeathObserver = GetComponentInChildren<PlayerDeathObserver>();
        }

        private void OnEnable() =>
            _playerDeathObserver.TriggerEnter += PlayerDeath;

        private void OnDisable() =>
            _playerDeathObserver.TriggerEnter -= PlayerDeath;

        public void StartAction() =>
            GetComponentInChildren<PlayerMovement>().enabled = true;

        public void StopAction() =>
            GetComponentInChildren<PlayerMovement>().enabled = false;

        private void PlayerDeath()
        {
            DiePlayer?.Invoke();
            Instantiate(_explosionParticle, _spawnPointParticle.transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }
}