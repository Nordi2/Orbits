using System;
using UnityEngine;

namespace CodeBase
{
    public class TriggerObserver : MonoBehaviour
    {
        public event Action TriggerEnter;

        private void OnTriggerEnter2D(Collider2D other) =>
            TriggerEnter?.Invoke();
    }
}