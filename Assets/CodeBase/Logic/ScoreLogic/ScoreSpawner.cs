using JetBrains.Annotations;

namespace CodeBase.Logic.ScoreLogic
{
    [UsedImplicitly]
    public class ScoreSpawner : IPauseAction
    {
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
    }
}