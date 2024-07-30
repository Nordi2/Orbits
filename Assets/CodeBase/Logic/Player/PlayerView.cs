using UnityEngine;

namespace Assets.CodeBase.Logic.Player
{
    public class PlayerView : MonoBehaviour
    {
        [Header("Settings PlayerDeath")]
        [SerializeField] private ParticleSystem _explosionParticle;
        [SerializeField] private Transform _spawnPointParticle;

        public void SpawnDeathEffect()
        {
            Instantiate(_explosionParticle, _spawnPointParticle.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}