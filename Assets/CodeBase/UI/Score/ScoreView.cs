using System;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        private ScoreWallet _scoreWallet;

        private void Construct(ScoreWallet scoreWallet) =>
            _scoreWallet = scoreWallet;

        private void UpdateCoinView() =>
            _textMeshPro.text = _scoreWallet.Score.ToString();
    }
}