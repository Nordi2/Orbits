using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class ScoreEffectSpawner : IDisposable, IPauseAction
    {
        private readonly EffectPool _effectPool;
        private readonly ScoreSpawner _scoreSpawner;

        public ScoreEffectSpawner(ScoreSpawner scoreSpawner, EffectPool effectPool)
        {
            _scoreSpawner = scoreSpawner;
            _effectPool = effectPool;
        }

        void IDisposable.Dispose() =>
            _scoreSpawner.OnScoreCollect -= SpawnEffect;

        public void StartAction() =>
            _scoreSpawner.OnScoreCollect += SpawnEffect;

        public void StopAction() { }

        private void SpawnEffect(Vector3 spawnPosition)
        {
            if (_effectPool.TryGetEffectInPool(out ParticleSystem effect))
            {
                effect.gameObject.SetActive(true);
                effect.transform.position = spawnPosition;
            }
        }
    }
}