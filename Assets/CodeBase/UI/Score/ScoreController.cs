using System;
using JetBrains.Annotations;
using Zenject;

namespace CodeBase.UI.Score
{
    [UsedImplicitly]
    public class ScoreController : IInitializable, IDisposable
    {
        private readonly ScoreWallet _scoreWallet;
        private readonly ScoreView _scoreView;

        public ScoreController(ScoreView scoreView, ScoreWallet scoreWallet)
        {
            _scoreView = scoreView;
            _scoreWallet = scoreWallet;
        }

        void IInitializable.Initialize()
        {
            UpdateScoreView();
            _scoreWallet.AddScoreEvent += UpdateScoreView;
        }

        void IDisposable.Dispose() =>
            _scoreWallet.AddScoreEvent -= UpdateScoreView;

        private void UpdateScoreView() =>
            _scoreView.UpdateScoreView(_scoreWallet.Score);
    }
}