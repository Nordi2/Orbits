using CodeBase.UI.Score;

namespace CodeBase.Data
{
    [System.Serializable]
    public class PlayerData
    {
        private int _score;
        private int _maxScore;
        public int Score => _score;
        public int MaxScore => _maxScore;

        public PlayerData(ScoreWallet wallet)
        {
            _score = wallet.Score;
            if (_score > _maxScore)
            {
                _maxScore = _score;
            }
        }

        public void SaveScore(ScoreWallet wallet)
        {
            _score = wallet.Score;
            if (_score > _maxScore)
            {
                _maxScore = _score;
            }
        }
    }
}