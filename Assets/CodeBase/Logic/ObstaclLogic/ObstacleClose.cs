using Config.Obstacles;
using Zenject;

namespace CodeBase.Logic.ObstaclLogic
{
    public class ObstacleClose : Obstacle
    {
        private ObstacleConfig _obstacleConfig;
        private ObstacleFacade _obstacleFacade;

        [Inject]
        private void Construct(ObstacleConfig obstacleConfig) =>
            _obstacleConfig = obstacleConfig;
        private void Start() =>
            _obstacleFacade = transform.GetComponentInParent<ObstacleFacade>();

        private void FixedUpdate() =>
            base.FixedUpdate(_obstacleFacade.transform, _obstacleConfig.Speed);
    }
}