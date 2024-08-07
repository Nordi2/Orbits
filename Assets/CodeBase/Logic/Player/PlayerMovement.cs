using System;
using System.Threading.Tasks;
using Assets.CodeBase.Logic.Player;
using CodeBase.Configs.Player;
using CodeBase.Infrastructure.Service;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic
{
    [UsedImplicitly]
    public class PlayerMovement : ITickable, IInitializable, IDisposable, IPauseAction
    {
        private readonly IInputService _inputService;
        private readonly PlayerConfig _playerConfig;
        private readonly PlayerView _playerView;

        private int _level;
        private float _currentRadius;
        private bool _isSwapping;
        private bool _isPause;

        public PlayerMovement(IInputService inputService, PlayerConfig playerConfig, PlayerView playerView)
        {
            _inputService = inputService;
            _playerConfig = playerConfig;
            _playerView = playerView;
        }

        void IInitializable.Initialize()
        {
            _currentRadius = _playerView.StartRadius;
            _inputService.OnClick += ClickMouseButton;
        }

        void IDisposable.Dispose() =>
            _inputService.OnClick -= ClickMouseButton;

        void ITickable.Tick()
        {
            if (_isPause)
                return;

            Move();
        }


        public void StopAction() =>
            _isPause = true;

        public void StartAction() =>
            _isPause = false;

        private void Move()
        {
            _playerView.RotateTransform.localPosition = Vector3.up * _currentRadius;
            float rotateValue = _playerConfig.Speed * Time.deltaTime * _playerView.StartRadius / _currentRadius;
            _playerView.transform.Rotate(0, 0, rotateValue);
        }

        private void ClickMouseButton()
        {
            if (_isPause || _isSwapping)
                return;

            ChangeRadiusAsync();
        }

        private async void ChangeRadiusAsync()
        {
            float moveStartRadius = _playerView.RotateRadii[_level];
            float moveEndRadius = _playerView.RotateRadii[(_level + 1) % _playerView.RotateRadii.Count];
            float moveOffset = moveEndRadius - moveStartRadius;
            float speed = 1 / _playerConfig.SwapTime;
            float timeElasped = 0f;

            _isSwapping = true;
            while (timeElasped < 1f)
            {
                float delta = speed * Time.deltaTime;

                timeElasped += delta;
                _currentRadius = moveStartRadius + timeElasped * moveOffset;

                await Task.Yield();
            }

            _level = (_level + 1) % _playerView.RotateRadii.Count;
            _currentRadius = _playerView.RotateRadii[_level];
            _isSwapping = false;
        }
    }
}