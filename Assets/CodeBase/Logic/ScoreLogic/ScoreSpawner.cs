using Zenject;

namespace CodeBase.Logic.ScoreLogic
{
    public class ScoreSpawner : ITickable
    {
        private readonly Factory _scoreFactory;

        public ScoreSpawner(Factory scoreFactory)
        {
            _scoreFactory = scoreFactory;
        }

        public void SpawnScore() =>
            _scoreFactory.Create();

        public void Tick()
        {
            var score = _scoreFactory.Create();
        }
    }
}