using CodeBase.Configs.Obstacle;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic
{
    public class Obstacle : MonoBehaviour, IPauseAction
    {
        private ObstacleConfig _obstacleConfig;
        private Transform _centalPoint;

        [Inject]
        public void Construct(ObstacleConfig obstacleConfig)
        {
            _obstacleConfig = obstacleConfig;
        }

        private void Awake() =>
            _centalPoint = gameObject.transform.parent;

        private void FixedUpdate() =>
            MoveObstacle(_obstacleConfig.Speed);

        public void StartAction() =>
            enabled = true;

        public void StopAction() =>
            enabled = false;

        private void MoveObstacle(float rotateSpeed) =>
           _centalPoint.Rotate(0, 0, rotateSpeed * Time.fixedDeltaTime);
    }
}