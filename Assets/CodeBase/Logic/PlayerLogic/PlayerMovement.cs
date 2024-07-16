using System.Collections;
using System.Collections.Generic;
using CodeBase.Configs.Player;
using CodeBase.Infrastructure.Service;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.PlayerLogic
{
    public class PlayerMovement : MonoBehaviour
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
        private Coroutine _changeRadiusCoroutine;


        [Inject]
        private void Construct(IInputService inputService, PlayerConfig playerConfig)
        {
            _inputService = inputService;
            _playerConfig = playerConfig;
        }

        #region MonoBehaviour

        private void Awake()
        {
            _level = 0;
            _currentRadius = _startRadius;
        }

        private void OnEnable() =>
            _inputService.OnClick += ClickMouseButton;

        private void OnDisable() =>
            _inputService.OnClick -= ClickMouseButton;

        private void Start()
        {
            _moveTime = _playerConfig.MoveTime;
            _rotateSpeed = _playerConfig.Speed;
        }

        private void FixedUpdate()
        {
            transform.localPosition = Vector3.up * _currentRadius;
            float rotateValue = _rotateSpeed * Time.fixedDeltaTime * _startRadius / _currentRadius;
            _rotateTransform.Rotate(0, 0, rotateValue);
        }

        #endregion

        #region Private Method

        private void ClickMouseButton() =>
            _changeRadiusCoroutine ??= StartCoroutine(ChangeRadius());

        private IEnumerator ChangeRadius()
        {
            float moveStartRadius = _rotateRadius[_level];
            float moveEndRadius = _rotateRadius[(_level + 1) % _rotateRadius.Count];
            float moveOffset = moveEndRadius - moveStartRadius;
            float speed = 1 / _moveTime;
            float timeElasped = 0f;
            while (timeElasped < 1f)
            {
                timeElasped += speed * Time.fixedDeltaTime;
                _currentRadius = moveStartRadius + timeElasped * moveOffset;
                yield return new WaitForFixedUpdate();
            }

            _level = (_level + 1) % _rotateRadius.Count;
            _currentRadius = _rotateRadius[_level];

            _changeRadiusCoroutine = null;
        }

        #endregion
    }
}