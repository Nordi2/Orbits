using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Logic
{
    public class EffectPool : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private ParticleSystem _effectPrefab;
        [SerializeField] private int _effectCount;

        private List<ParticleSystem> _pool = new();

        private void Awake()
        {
            for (int i = 0; i < _effectCount; i++)
            {
                ParticleSystem effect = Instantiate(_effectPrefab, _container);
                _pool.Add(effect);
                effect.gameObject.SetActive(false);
            }
        }

        public bool TryGetEffectInPool(out ParticleSystem result)
        {
            result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);
            return result != null;
        }
    }
}