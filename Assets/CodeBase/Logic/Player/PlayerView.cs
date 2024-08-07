using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Logic.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _explosionParticle;
        [SerializeField] private Transform _spawnPointParticle;

        [SerializeField] private float _startRadius;
        [SerializeField] private List<float> _rotateRadii;
        [SerializeField] private Transform _rotateTransform;

        public float StartRadius => _startRadius;
        public List<float> RotateRadii => _rotateRadii;
        public Transform RotateTransform => _rotateTransform;

        public void PlayDeathEffect()
        {
            Instantiate(_explosionParticle, _spawnPointParticle.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}