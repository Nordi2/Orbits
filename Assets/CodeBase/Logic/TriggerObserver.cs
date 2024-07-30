using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class TriggerObserver<T> : MonoBehaviour where T : MonoBehaviour
    {
        public event Action TriggerEnter;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out T Object))
            {
                TriggerEnter?.Invoke();
            }
        }
    }
}