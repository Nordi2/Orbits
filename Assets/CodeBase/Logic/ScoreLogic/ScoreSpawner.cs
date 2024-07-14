using System;
using JetBrains.Annotations;
using Zenject;

namespace CodeBase.Logic.ScoreLogic
{
    [UsedImplicitly]
    public class ScoreSpawner : IDisposable, IPauseAction
    {
        private readonly Factory _scoreFactory;
        private Score _currentScore;
        private bool _isPause;

        public ScoreSpawner(Factory scoreFactory)
        {
            _scoreFactory = scoreFactory;
        }
        public void Dispose()
        {
            if (_currentScore != null)
            {
                _currentScore.OnScoreCollected -= ScoreCollected;
            }
        }

        private void SpawnScore()
        {
            if (!_isPause)
            {
                _currentScore = _scoreFactory.Create();
                _currentScore.OnScoreCollected += ScoreCollected;
            }
        }

        private void ScoreCollected()
        {
            _currentScore.OnScoreCollected -= ScoreCollected;
            SpawnScore();
        }

        public void StopAction() =>
            _isPause = true;

        public void StartAction()
        {
            _isPause = false;
            SpawnScore();
        }
    }
}