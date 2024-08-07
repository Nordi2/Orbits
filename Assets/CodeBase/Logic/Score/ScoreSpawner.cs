using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using System;

namespace CodeBase.Logic
{
    [UsedImplicitly]
    public class ScoreSpawner : IPauseAction, IDisposable
    {
        private const int MaxRotationAngle = 37;
        private const float AngleMultiplier = 10f;

        private readonly List<float> _spawnPosX = new()
        { Constant.SizeSmallCircle, Constant.SizeMiddleCircle, Constant.SizeFarCircle };

        private readonly ScoreFactory _scoreFactory;
        private Score _score;

        public event Action<Vector3> OnScoreCollect;

        public ScoreSpawner(ScoreFactory scoreScoreFactory)
        {
            _scoreFactory = scoreScoreFactory;
        }

        void IDisposable.Dispose() =>
            _score.OnScoreCollect -= ScoreCollectHandler;

        public void StopAction() { }

        public void StartAction()
        {
            SpawnScore();
            SwapPosition();
        }

        private void SpawnScore()
        {
            _score = _scoreFactory.Create();
            _score.OnScoreCollect += ScoreCollectHandler;
        }

        private void ScoreCollectHandler()
        {
            OnScoreCollect?.Invoke(_score.ViewTranform.position);
            SwapPosition();
        }
        private void SwapPosition()
        {
            _score.ViewTranform.localPosition = GetSpawnPosition();
            _score.transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, MaxRotationAngle) * AngleMultiplier);
        }

        private Vector3 GetSpawnPosition() =>
            Vector3.right * _spawnPosX[UnityEngine.Random.Range(0, _spawnPosX.Count)];

    }
}