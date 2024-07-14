using System;
using CodeBase.Logic.ObstaclLogic;
using UnityEngine;

namespace CodeBase.Logic.PlayerLogic
{
    public class DeathObserver : MonoBehaviour
    {
        public event Action TriggerEnter;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Obstacle obstacle))
            {
                TriggerEnter?.Invoke();
            }
        }
    }
}