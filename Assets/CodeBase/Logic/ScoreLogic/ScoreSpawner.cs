using Zenject;

namespace CodeBase.Logic.ScoreLogic
{
    // Переделать сингелтон , хочу сделать спавн монет , после того , кок подобрал последнию , через сигналы пытался.
    public class ScoreSpawner : ITickable, IInitializable
    {
        public static ScoreSpawner Instace;
        private readonly Factory _scoreFactory;

        public ScoreSpawner(Factory scoreFactory) =>
            _scoreFactory = scoreFactory;

        public void SpawnScore()
        {
            var score = _scoreFactory.Create();
        }

        public void Tick()
        {
            /*   if (!_spawn)
               {
                   var score = _scoreFactory.Create();
                   _spawn = true;
               }*/
        }

        public void Initialize()
        {
            if (Instace == null)
            {
                Instace = this;
            }
            SpawnScore();
        }
    }
}