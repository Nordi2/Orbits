using System;
using System.Threading.Tasks;
using Assets.CodeBase.Logic.Player;
using CodeBase.Configs.Player;
using CodeBase.Infrastructure.Service;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic
{
    public class PlayerMovement : ITickable, IInitializable, IDisposable, IPauseAction
    {
        private readonly IInputService _inputService;
        private readonly PlayerConfig _playerConfig;
        private readonly PlayerView _playerView;

        private int _level;
        private float _rotateSpeed;
        private float _currentRadius;
        private float _moveTime;
        private bool _isSwapping;
        private bool _isPause;

        public PlayerMovement(IInputService inputService, PlayerConfig playerConfig, PlayerView playerView)
        {
            _inputService = inputService;
            _playerConfig = playerConfig;
            _playerView = playerView;
        }

        public void Initialize()
        {
            _currentRadius = _playerView.StartRadiys;
            _moveTime = _playerConfig.SwapTime;
            _rotateSpeed = _playerConfig.Speed;
            _inputService.OnClick += ClickMouseButton;
        }
        public void Dispose()
        {
            _inputService.OnClick -= ClickMouseButton;
        }

        public void Tick()
        {
            if (_isPause)
            {
                _playerView.RotateTransform.localPosition = Vector3.up * _currentRadius;
                float rotateValue = _rotateSpeed * Time.deltaTime * _playerView.StartRadiys / _currentRadius;
                _playerView.transform.Rotate(0, 0, rotateValue);
            }
        }

        public void StopAction() =>
            _isPause = false;

        public void StartAction() =>
            _isPause = true;

        private void ClickMouseButton()
        {
            if (_isPause)
            {
                if (!_isSwapping)
                {
                    ChangeRadiusAsync();
                }
            }
        }

        private async void ChangeRadiusAsync()
        {
            float moveStartRadius = _playerView.RotateRadius[_level];
            float moveEndRadius = _playerView.RotateRadius[(_level + 1) % _playerView.RotateRadius.Count];
            float moveOffset = moveEndRadius - moveStartRadius;
            float speed = 1 / _moveTime;
            float timeElasped = 0f;

            _isSwapping = true;
            while (timeElasped < 1f)
            {
                float delta = speed * Time.deltaTime;

                timeElasped += delta;
                _currentRadius = moveStartRadius + timeElasped * moveOffset;

                await Task.Yield();
            }

            _level = (_level + 1) % _playerView.RotateRadius.Count;
            _currentRadius = _playerView.RotateRadius[_level];
            _isSwapping = false;
        }

    }
}