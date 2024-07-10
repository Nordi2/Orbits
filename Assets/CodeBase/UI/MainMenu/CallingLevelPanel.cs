using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.MainMenu
{
    public class CallingLevelPanel : MonoBehaviour
    {
        [SerializeField] private RectTransform _mainMenuPanel;
        [SerializeField] private RectTransform _callingLevelPanel;
        [SerializeField] private Button _buttonScrollThroughRight;
        [SerializeField] private Button _buttonScrollThroughLeft;

        private void OnEnable()
        {
            _buttonScrollThroughRight.onClick.AddListener(PlayAnimationCallingLevelPanel);
            _buttonScrollThroughLeft.onClick.AddListener(PlayAnimationCallingMainMenu);
        }

        private void OnDisable()
        {
            _buttonScrollThroughRight.onClick.RemoveListener(PlayAnimationCallingLevelPanel);
            _buttonScrollThroughLeft.onClick.RemoveListener(PlayAnimationCallingMainMenu);
        }

        private void PlayAnimationCallingMainMenu()
        {
            _mainMenuPanel.DOAnchorPos(Vector2.zero, 1, false);
            _callingLevelPanel.DOAnchorPos(new Vector2(-1500, 0), 1, false);
        }

        private void PlayAnimationCallingLevelPanel()
        {
            _mainMenuPanel.DOAnchorPos(new Vector2(1500, 0), 1, false);
            _callingLevelPanel.DOAnchorPos(Vector2.zero, 1, false);
        }
    }
}