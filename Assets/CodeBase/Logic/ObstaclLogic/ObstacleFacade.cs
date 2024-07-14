using UnityEngine;

namespace CodeBase.Logic.ObstaclLogic
{
    public class ObstacleFacade : MonoBehaviour, IObstacleFacade
    {
        public void StopAction() =>
            GetComponentInChildren<Obstacle>().enabled = false;

        public void StartAction() =>
            GetComponentInChildren<Obstacle>().enabled = true;
    }
}