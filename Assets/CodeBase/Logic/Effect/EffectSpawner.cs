using CodeBase.Logic;
using System;
using UnityEngine;

public class EffectSpawner : IDisposable, IPauseAction
{
    private readonly EffectPool _effectPool;
    private readonly ScoreSpawner _scoreSpawner;

    private Score _score;

    public EffectSpawner(ScoreSpawner scoreSpawner, EffectPool effectPool)
    {
        _scoreSpawner = scoreSpawner;
        _effectPool = effectPool;
    }

    public void Dispose() => 
        _scoreSpawner.SpawnEffect -= SpawnEffect;

    public void StartAction()
    {
        _scoreSpawner.SpawnEffect += SpawnEffect;
        _score = _scoreSpawner.Score;
    }

    public void StopAction() { }
    private void SpawnEffect()
    {
        if (_effectPool.TryGetEffectInPool(out ParticleSystem effect))
        {
            effect.gameObject.SetActive(true);
            effect.transform.position = _score.ViewTranform.position;
        }
    }


}
