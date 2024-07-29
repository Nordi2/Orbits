using System;
using JetBrains.Annotations;

namespace CodeBase.UI.Score
{
    [UsedImplicitly]
    public class ScoreWallet
    {
        private int _score;
        public int Score => _score;

        public event Action AddScoreEvent;

        public void AddScore()
        {
            _score++;
            AddScoreEvent?.Invoke();
        }
    }
}