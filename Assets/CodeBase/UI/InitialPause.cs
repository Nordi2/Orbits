using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Start() {}
           // PlayPause();

        private void PlayPause() =>
            Time.timeScale = 0;

        private void ResumeGame()
        {
            Time.timeScale = 1;
            _text.gameObject.SetActive(false);
        }
    }
}