using Config.Obstacles;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class ObstacleInstaller : MonoInstaller
    {
        [SerializeField] private ObstacleConfig _obstacleConfig;

        public override void InstallBindings()
        {
            RegisterObstacleConfig();
        }

        private void RegisterObstacleConfig()
        {
            Container
                .BindInstance(_obstacleConfig)
                .AsSingle();
        }
    }
}