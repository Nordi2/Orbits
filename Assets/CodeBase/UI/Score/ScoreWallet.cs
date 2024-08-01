using System;
using JetBrains.Annotations;

namespace CodeBase.UI.Score
{
    [UsedImplicitly]
    public class ScoreWallet
    {
        private int _score;

        public event Action AddScoreEvent;
        public int Score => _score;

        public void AddScore()
        {
            _score++;
            AddScoreEvent?.Invoke();
        }
    }
}