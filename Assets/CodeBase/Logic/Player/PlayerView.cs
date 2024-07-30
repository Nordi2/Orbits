using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Logic.Player
{
    public class PlayerView : MonoBehaviour
    {
        [Header("Settings PlayerDeath")]
        [SerializeField] private ParticleSystem _explosionParticle;
        [SerializeField] private Transform _spawnPointParticle;

        [Header("Settings PlayerMovemnt")]
        [SerializeField] private float _startRadius;
        [SerializeField] private List<float> _rotateRadius;
        [SerializeField] private Transform _rotateTransform;

        public float StartRadiys => _startRadius;
        public List<float> RotateRadius => _rotateRadius;
        public Transform RotateTransform => _rotateTransform;

        public void SpawnDeathEffect()
        {
            Instantiate(_explosionParticle, _spawnPointParticle.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}