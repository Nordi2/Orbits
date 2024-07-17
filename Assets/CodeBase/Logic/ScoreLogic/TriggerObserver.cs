using System;
using CodeBase.Logic.PlayerLogic;
using UnityEngine;

namespace CodeBase.Logic.ScoreLogic
{
    public class TriggerObserver : MonoBehaviour
    {
        public event Action TriggerEnter;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerMovement playerFacade))
            {
                TriggerEnter?.Invoke();
            }
        }
    }
}