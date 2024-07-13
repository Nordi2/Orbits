using System.Collections;
using System.Collections.Generic;
using CodeBase.Configs;
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

        private void Start()
        {
            _moveTime = _playerConfig.MoveTime;
            _rotateSpeed = _playerConfig.Speed;
        }

        private void Update()
        {
            if (changeRadiusCoroutine == null && /*_inputService.СlickMouseButton*/ Input.GetMouseButtonDown(0))
            {
                changeRadiusCoroutine = StartCoroutine(ChangeRadius());
            }
        }

        private void FixedUpdate()
        {
            transform.localPosition = Vector3.up * currentRadius;
            float rotateValue = _rotateSpeed * Time.fixedDeltaTime * _startRadius / currentRadius;
            _rotateTransform.Rotate(0, 0, rotateValue);
        }

        #endregion

        private IEnumerator ChangeRadius()
        {
            float moveStartRadius = _rotateRadius[level]; //0.95
            float moveEndRadius = _rotateRadius[(level + 1) % _rotateRadius.Count]; //1.7 % 4
            float moveOffset = moveEndRadius - moveStartRadius; //1.7-0.95
            float speed = 1 / _moveTime; //1/0.16
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
    }
}