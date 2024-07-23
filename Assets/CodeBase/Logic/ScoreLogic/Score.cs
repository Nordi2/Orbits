using CodeBase.UI.Score;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.ScoreLogic
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Transform _centerTransform;

        private ScoreTriggerObserver _scoreTriggerObserver;
        private ScoreWallet _scoreWallet;
        private EffectPool _effectPool;
        private ScoreSpawner _scoreSpawner;

        [Inject]
        public void Construct(ScoreWallet scoreWallet, EffectPool effectPool, ScoreSpawner scoreSpawner)
        {
            _effectPool = effectPool;
            _scoreWallet = scoreWallet;
            _scoreSpawner = scoreSpawner;
        }

        private void Awake()
        {
            _scoreTriggerObserver = GetComponent<ScoreTriggerObserver>();
            _centerTransform = GetComponentInParent<ScoreMark>().transform;
        }

        private void Start()
        {
            _scoreSpawner.SwapPosition(_centerTransform, gameObject.transform);
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
                effect.transform.position = transform.position;
            }

            _scoreSpawner.SwapPosition(_centerTransform, gameObject.transform);
            _scoreWallet.AddScore();
        }
    }
}