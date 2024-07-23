using System;
using Unity.Mathematics;
using UnityEngine;

namespace CodeBase.Logic.PlayerLogic
{
    public class PlayerDeath : MonoBehaviour
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
            _playerDeathObserver.TriggerEnter += CollisionWithAnObstacle;

        private void OnDisable() =>
            _playerDeathObserver.TriggerEnter += CollisionWithAnObstacle;

        private void CollisionWithAnObstacle()
        {
            DiePlayer?.Invoke();
            Instantiate(_explosionParticle, _spawnPointParticle.transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }
}