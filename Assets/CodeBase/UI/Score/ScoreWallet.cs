namespace CodeBase.UI.Score
{
    public class ScoreWallet
    {
        private int _score;
        public int Score => _score;

        public void AddScore() =>
            _score++;
    }
}