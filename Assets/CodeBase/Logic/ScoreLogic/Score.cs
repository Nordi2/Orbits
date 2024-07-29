using CodeBase.UI.Score;
using System;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.ScoreLogic
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Transform _viewTransform;

        private ScoreTriggerObserver _scoreTriggerObserver;
        private ScoreWallet _scoreWallet;
        private EffectPool _effectPool;


        public event Action OnScoreCollect;
        public Transform ViewTranform => _viewTransform;

        [Inject]
        public void Construct(ScoreWallet scoreWallet, EffectPool effectPool)
        {
            _effectPool = effectPool;
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
            if (_effectPool.TryGetEffectInPool(out ParticleSystem effect))
            {
                effect.gameObject.SetActive(true);
                effect.transform.position = _viewTransform.position;
            }

            OnScoreCollect?.Invoke();
            _scoreWallet.AddScore();
        }
    }
}