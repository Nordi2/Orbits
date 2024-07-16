using System;
using CodeBase.Data;
using CodeBase.SaveSystem;
using JetBrains.Annotations;
using Zenject;

namespace CodeBase.Logic
{
    [UsedImplicitly]
    public class LoadScore : IInitializable
    {
        private int _score;
        private int _maxScore;
        public int Score => _score;
        public int MaxScore => _maxScore;

        public void Initialize()
        {
            PlayerData data = LoadProgress.LoadPlayer();
            if (data == null)
            {
                _score = Constant.InitialScore;
                _maxScore = Constant.InitialScore;
            }
            else
            {
                _score = data.Score;
                if (_score > _maxScore)
                {
                    _maxScore = _score;
                }
            }
        }
    }
}