using CodeBase.UI.Score;
using System;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Transform _viewTransform;

        private ScoreTriggerObserver _scoreTriggerObserver;
        private ScoreWallet _scoreWallet;

        public event Action OnScoreCollect;
        public Transform ViewTranform => _viewTransform;

        [Inject]
        public void Construct(ScoreWallet scoreWallet)
        {
            _scoreWallet = scoreWallet;
        }

        private void Awake()
        {
            _scoreTriggerObserver = GetComponentInChildren<ScoreTriggerObserver>();
        }

        private void OnEnable() =>
            _scoreTriggerObserver.TriggerEnter += ScoreTriggerEnter;

        private void OnDisable() =>
            _scoreTriggerObserver.TriggerEnter -= ScoreTriggerEnter;

        private void ScoreTriggerEnter()
        {
            OnScoreCollect?.Invoke();
            _scoreWallet.AddScore();
        }
    }
}