using Assets.CodeBase.Logic.Player;
using CodeBase.Logic;
using CodeBase.UI.Score;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Score _scorePrefab;
        [SerializeField] private Obstacle _obstacleFar;
        [SerializeField] private Obstacle _obstacleMiddle;
        [SerializeField] private Obstacle _obstacleClose;

        public override void InstallBindings()
        {
            RegisterObstacle(_obstacleClose);
            RegisterObstacle(_obstacleMiddle);
            RegisterObstacle(_obstacleFar);

            Container
                .Bind<IPauseAction>()
                .To<PlayerMovement>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ScoreSpawner>()
                .AsSingle();

            Container
                .BindInterfacesTo<EffectSpawner>()
                .AsSingle();

            Container
                .BindFactory<Score, ScoreFactory>()
                .FromComponentInNewPrefab(_scorePrefab);

            Container
                .Bind<EffectPool>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<ScoreView>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<PlayerView>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<PlayerDeathObserver>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void RegisterObstacle<T>(T obstacle) where T : IPauseAction =>
            Container
                .Bind<IPauseAction>()
                .To<T>()
                .FromInstance(obstacle)
                .AsCached();
    }
}