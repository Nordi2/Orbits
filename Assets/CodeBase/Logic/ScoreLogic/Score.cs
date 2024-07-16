using System.Collections.Generic;
using CodeBase.UI.Score;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace CodeBase.Logic.ScoreLogic
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Transform _centerTranform;
        [SerializeField] private List<float> _spawnPosX;

        private TriggerObserver _triggerObserver;
        private ScoreWallet _scoreWallet;
        private EffectPool _effectPool;

        [Inject]
        private void Construct(ScoreWallet scoreWallet, EffectPool effectPool)
        {
            _effectPool = effectPool;
            _scoreWallet = scoreWallet;
        }

        #region MonoBehaviour

        private void Awake() =>
            _triggerObserver = GetComponent<TriggerObserver>();

        private void Start() =>
            SwapPosition();


        private void OnEnable() =>
            _triggerObserver.TriggerEnter += TriggerEnter;

        private void OnDisable() =>
            _triggerObserver.TriggerEnter -= TriggerEnter;

        #endregion

        private void TriggerEnter()
        {
            if (_effectPool.TryGetEffectInPool(out ParticleSystem effect))
            {
                effect.gameObject.SetActive(true);
                effect.transform.position = transform.position;
            }

            SwapPosition();
            _scoreWallet.AddScore();
        }

        private void SwapPosition()
        {
            transform.localPosition = GetSpawnPosition();
            _centerTranform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 37) * 10f);
        }

        private Vector3 GetSpawnPosition() =>
            Vector3.right * _spawnPosX[Random.Range(0, _spawnPosX.Count)];
    }
}