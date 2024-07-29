using CodeBase.Data;
using CodeBase.Infrastructure.Service;
using CodeBase.UI.Score;
using JetBrains.Annotations;
using Zenject;

namespace CodeBase.Logic
{
    [UsedImplicitly]
    public class LoadScore : IInitializable
    {
        private ScoreView _scoreView;

        public LoadScore(ScoreView scoreView)
        {
            _scoreView = scoreView;
        }

        void IInitializable.Initialize()
        {
            PlayerData data = LoadProgress.LoadPlayer();
            _scoreView.UpdateScoreView(data?.Score ?? 0);
        }
    }
}