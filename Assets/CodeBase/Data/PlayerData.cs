using CodeBase.UI.Score;

namespace CodeBase.Data
{
    [System.Serializable]
    public class PlayerData
    {
        private int _score;
        public int Score => _score;

        public PlayerData(ScoreWallet wallet)
        {
            _score = wallet.Score;
        }
    }
}