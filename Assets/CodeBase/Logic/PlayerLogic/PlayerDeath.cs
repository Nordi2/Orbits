using System;
using Unity.Mathematics;
using UnityEngine;

namespace CodeBase.Logic.PlayerLogic
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _explosionParticle;
        [SerializeField] private Transform _spawnPointParticle;
        [SerializeField] private PlayerDeathObserver _playerDeathObserver;

        public event Action DiePlayer;

        private void OnEnable() =>
            _playerDeathObserver.TriggerEnter += CollisionWithAnObstacle;

        private void OnDisable() =>
            _playerDeathObserver.TriggerEnter += CollisionWithAnObstacle;

        private void CollisionWithAnObstacle()
        {
            DiePlayer?.Invoke();
            Instantiate(_explosionParticle, _spawnPointParticle.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}