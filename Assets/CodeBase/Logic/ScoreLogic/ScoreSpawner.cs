using Zenject;

namespace CodeBase.Logic.ScoreLogic
{
    public class ScoreSpawner : ITickable
    {
        private readonly Score.Factory _scoreFactory;

        public ScoreSpawner(Score.Factory scoreFactory)
        {
            _scoreFactory = scoreFactory;
        }

        public void Tick()
        {
            var score = _scoreFactory.Create();
        }
    }
}