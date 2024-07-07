using System.Collections;
using TMPro;
using UnityEngine;

namespace CodeBase
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _highScoreText;
        [SerializeField] private TMP_Text _newBestText;

        private void Awake()
        {
            if (GameManager.Instance.IsInitialize)
            {
                StartCoroutine(ShowScore());
            }
            else
            {
                _scoreText.gameObject.SetActive(false);
                _newBestText.gameObject.SetActive(false);
                _highScoreText.text = GameManager.Instance.HighScore.ToString();
            }
        }

        private IEnumerator ShowScore()
        {
            yield return null;
        }

        [SerializeField] private AudioClip _clickClip;

        public void ClickedPlay()
        {
            SoundManager.Instance.PlaySound(_clickClip);
            GameManager.Instance.GoToGamePlay();
        }
    }
}
