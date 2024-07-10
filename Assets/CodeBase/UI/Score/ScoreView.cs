using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        private ScoreWallet _scoreWallet;

        [Inject]
        private void Construct(ScoreWallet scoreWallet) =>
            _scoreWallet = scoreWallet;

        #region MonoBehaviour

        private void Start() =>
            UpdateCoinView();

        private void OnEnable() =>
            _scoreWallet.AddScoreEvent += UpdateCoinView;

        private void OnDisable() =>
            _scoreWallet.AddScoreEvent -= UpdateCoinView;

        #endregion

        private void UpdateCoinView() =>
            _textMeshPro.text = _scoreWallet.Score.ToString();
    }
}