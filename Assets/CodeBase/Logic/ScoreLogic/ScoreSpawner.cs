using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace CodeBase.Logic.ScoreLogic
{
    [UsedImplicitly]
    public class ScoreSpawner : IPauseAction
    {
        private readonly List<float> _spawnPosX = new()
            { Constant.SizeSmallCircle, Constant.SizeMiddleCircle, Constant.SizeFarCircle };

        private readonly ScoreFactory _scoreFactory;


        private bool _isPause;

        public ScoreSpawner(ScoreFactory scoreScoreFactory)
        {
            _scoreFactory = scoreScoreFactory;
        }

        private void SpawnScore()
        {
            if (!_isPause)
            {
                _scoreFactory.Create();
            }
        }

        public void StopAction() =>
            _isPause = true;

        public void StartAction()
        {
            _isPause = false;
            SpawnScore();
        }

        public void SwapPosition(Transform parentTransform, Transform localTransform)
        {
            localTransform.localPosition = GetSpawnPosition();
            parentTransform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 37) * 10f);
        }

        private Vector3 GetSpawnPosition() =>
            Vector3.right * _spawnPosX[Random.Range(0, _spawnPosX.Count)];
    }
}