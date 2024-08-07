using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class TriggerObserver<TImplementation> : MonoBehaviour where TImplementation : MonoBehaviour
    {
        public event Action TriggerEnter;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out TImplementation Object))
            {
                TriggerEnter?.Invoke();
            }
        }
    }
}