﻿using System;
using JetBrains.Annotations;
using Zenject;

namespace CodeBase.UI.Score
{
    [UsedImplicitly]
    public class ScoreController : IInitializable, IDisposable
    {
        private ScoreWallet _scoreWallet;
        private ScoreView _scoreView;

        [Inject]
        private void Construct(ScoreWallet scoreWallet, ScoreView scoreView)
        {
            _scoreView = scoreView;
            _scoreWallet = scoreWallet;
        }

        public void Initialize()
        {
            UpdateCoinView();
            _scoreWallet.AddScoreEvent += UpdateCoinView;
        }

        public void Dispose()
        {
            _scoreWallet.AddScoreEvent -= UpdateCoinView;
        }

        private void UpdateCoinView() =>
            _scoreView.UpdateCoinView(_scoreWallet.Score);
    }
}