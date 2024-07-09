using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrastructure.Service;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.PlayerLogic
{
    public class PlayerMovement : MonoBehaviour
    {
        private bool canClick;
        [SerializeField] private float _startRadius;
        [SerializeField] private float _moveTime;

        [SerializeField] private List<float> _rotateRadius;
        private float currentRadius;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private Transform _rotateTransform;
        private IInputService _inputService;
        private int level;
    
        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        private void Awake()
        {
            canClick = true;
            level = 0;
            currentRadius = _startRadius;
        }
        private void Update()
        {
            if (canClick && Input.GetMouseButtonDown(0))
            {
                StartCoroutine(ChangeRadius());
            }
        }
        private void FixedUpdate()
        {
            transform.localPosition = Vector3.up * currentRadius;
            float rotateValue = _rotateSpeed * Time.fixedDeltaTime * _startRadius / currentRadius;
            _rotateTransform.Rotate(0, 0, rotateValue);
        }
        private IEnumerator ChangeRadius()
        {
            canClick = false;
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

            canClick = true;
            level = (level + 1) % _rotateRadius.Count;
            currentRadius = _rotateRadius[level];
        }   
    }
}
