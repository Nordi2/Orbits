using CodeBase.Configs.Obstacle;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class ObstacleInstaller : MonoInstaller
    {
        [SerializeField] private ObstacleConfig _obstacleConfig;

        public override void InstallBindings()
        {
            Container
                .BindInstance(_obstacleConfig)
                .AsSingle();
        }
    }
}