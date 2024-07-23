using System;
using CodeBase.Infrastructure.Service;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI
{
    public class PauseMenuText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        private Tween _tween;
        private IInputService _inputService;
        [Inject]
        public void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void Start() =>
            _tween = _text.DOFade(0, 1).SetLoops(-1, LoopType.Yoyo);

        private void OnEnable() =>
            _inputService.OnClick += StopAnimation;

        private void OnDisable() =>
            _inputService.OnClick -= StopAnimation;

        private void StopAnimation()
        {
            _tween.Kill();
            _text.gameObject.SetActive(false);
            _inputService.OnClick -= StopAnimation;
        }
    }
}