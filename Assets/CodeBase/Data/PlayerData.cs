using CodeBase.UI.Score;

namespace CodeBase.Data
{
    [System.Serializable]
    public class PlayerData
    {
        private int _score;
        public int Score => _score;

        public void NewRecord(int score)
        {
            _score = score;
        }
    }
}