using TMPro;
using UnityEngine;

namespace CodeBase.UI.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        public void UpdateCoinView(int score) =>
            _textMeshPro.text = score.ToString();
    }
}