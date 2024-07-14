using System.Collections;
using System.Collections.Generic;
using CodeBase.Configs.Player;
using CodeBase.Infrastructure.Service;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.PlayerLogic
{
    public class PlayerMovement : MonoBehaviour, IPauseAction
    {
        [SerializeField] private float _startRadius;
        [SerializeField] private List<float> _rotateRadius;
        [SerializeField] private Transform _rotateTransform;

        private IInputService _inputService;
        private PlayerConfig _playerConfig;

        private int level;
        private float _rotateSpeed;
        private float currentRadius;
        private float _moveTime;
        private Coroutine changeRadiusCoroutine;


        [Inject]
        private void Construct(IInputService inputService, PlayerConfig playerConfig)
        {
            _inputService = inputService;
            _playerConfig = playerConfig;
        }

        #region MonoBehaviour

        private void Awake()
        {
            level = 0;
            currentRadius = _startRadius;
        }

        private void OnEnable() =>
            _inputService.OnClickMouseButton += ClickMouseButton;

        private void OnDisable() =>
            _inputService.OnClickMouseButton -= ClickMouseButton;

        private void Start()
        {
            _moveTime = _playerConfig.MoveTime;
            _rotateSpeed = _playerConfig.Speed;
        }

        private void FixedUpdate()
        {
            transform.localPosition = Vector3.up * currentRadius;
            float rotateValue = _rotateSpeed * Time.fixedDeltaTime * _startRadius / currentRadius;
            _rotateTransform.Rotate(0, 0, rotateValue);
        }

        #endregion

        #region Public Method

        public void StopAction() =>
            enabled = false;

        public void StartAction() =>
            enabled = true;

        #endregion

        #region Private Method

        private void ClickMouseButton() =>
            changeRadiusCoroutine ??= StartCoroutine(ChangeRadius());

        private IEnumerator ChangeRadius()
        {
            float moveStartRadius = _rotateRadius[level];
            float moveEndRadius = _rotateRadius[(level + 1) % _rotateRadius.Count];
            float moveOffset = moveEndRadius - moveStartRadius;
            float speed = 1 / _moveTime;
            float timeElasped = 0f;
            while (timeElasped < 1f)
            {
                timeElasped += speed * Time.fixedDeltaTime;
                currentRadius = moveStartRadius + timeElasped * moveOffset;
                yield return new WaitForFixedUpdate();
            }

            level = (level + 1) % _rotateRadius.Count;
            currentRadius = _rotateRadius[level];

            changeRadiusCoroutine = null;
        }

        #endregion
    }
}