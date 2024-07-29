using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBase.Configs.Player;
using CodeBase.Infrastructure.Service;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic
{
    public class PlayerMovement : MonoBehaviour, IPauseAction
    {
        [SerializeField] private float _startRadius;
        [SerializeField] private List<float> _rotateRadius;
        [SerializeField] private Transform _rotateTransform;

        private IInputService _inputService;
        private PlayerConfig _playerConfig;

        private int _level;
        private float _rotateSpeed;
        private float _currentRadius;
        private float _moveTime;
        private bool _isSwapping;

        [Inject]
        private void Construct(IInputService inputService, PlayerConfig playerConfig)
        {
            _inputService = inputService;
            _playerConfig = playerConfig;
        }

        private void Awake()
        {
            _currentRadius = _startRadius;
        }

        private void OnEnable() =>
            _inputService.OnClick += ClickMouseButton;

        private void OnDisable() =>
            _inputService.OnClick -= ClickMouseButton;

        private void Start()
        {
            _moveTime = _playerConfig.SwapTime;
            _rotateSpeed = _playerConfig.Speed;
        }

        private void Update()
        {
            transform.localPosition = Vector3.up * _currentRadius;
            float rotateValue = _rotateSpeed * Time.deltaTime * _startRadius / _currentRadius;
            _rotateTransform.Rotate(0, 0, rotateValue);
        }
        public void StopAction() =>
            GetComponent<PlayerMovement>().enabled = false;

        public void StartAction() =>
            GetComponent<PlayerMovement>().enabled = true;

        private void ClickMouseButton()
        {
            if (!_isSwapping)
            {
                ChangeRadiusAsync();
            }
        }

        private async void ChangeRadiusAsync()
        {
            float moveStartRadius = _rotateRadius[_level];
            float moveEndRadius = _rotateRadius[(_level + 1) % _rotateRadius.Count];
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

            _level = (_level + 1) % _rotateRadius.Count;
            _currentRadius = _rotateRadius[_level];
            _isSwapping = false;
        }
    }
}