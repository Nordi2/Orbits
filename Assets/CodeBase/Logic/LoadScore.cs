using Assets.CodeBase.Infrastructure.Service.SaveSystem;
using CodeBase.Data;
using CodeBase.UI.Score;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic
{
    [UsedImplicitly]
    public class LoadScore : IInitializable
    {
        private ScoreView _scoreView;
        private int _score;
        public int Score => _score;

        public LoadScore(ScoreView scoreView)
        {
            _scoreView = scoreView;
        }

        void IInitializable.Initialize()
        {
            PlayerData data = LoadProgress.LoadPlayer();
            _score = data?.Score ?? Constant.InitialScore;
            _scoreView.UpdateScoreView(_score);
        }
    }
}