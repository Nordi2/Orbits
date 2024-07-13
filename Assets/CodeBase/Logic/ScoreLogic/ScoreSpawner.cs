using System;
using JetBrains.Annotations;
using Zenject;

namespace CodeBase.Logic.ScoreLogic
{
    [UsedImplicitly]
    public class ScoreSpawner : IInitializable, IDisposable , IPause
    {
        private readonly Factory _scoreFactory;
        private Score _currentScore;

        public ScoreSpawner(Factory scoreFactory)
        {
            _scoreFactory = scoreFactory;
        }

        public void Initialize() =>
            SpawnScore();

        public void Dispose()
        {
            if (_currentScore != null)
            {
                _currentScore.OnScoreCollected -= ScoreCollected;
            }
        }

        private void SpawnScore()
        {
            _currentScore = _scoreFactory.Create();
            _currentScore.OnScoreCollected += ScoreCollected;
        }

        private void ScoreCollected()
        {
            _currentScore.OnScoreCollected -= ScoreCollected;
            SpawnScore();
        }
    }
}