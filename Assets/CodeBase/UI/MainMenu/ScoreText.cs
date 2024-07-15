using CodeBase.Logic;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.MainMenu
{
    public class ScoreText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentScore;
        [SerializeField] private TextMeshProUGUI _maxScore;
        [SerializeField] private TextMeshProUGUI _currentScoreText;
        private LoadScore _score;

        [Inject]
        public void Construct(LoadScore score)
        {
            _score = score;
        }

        private void Start()
        {
            _maxScore.text = _score.MaxScore.ToString();
            _currentScore.text = _score.Score.ToString();
            _currentScoreText.text = Constant.CurrentScoreText;
        }
    }
}