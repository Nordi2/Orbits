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

            BindInHierarchy<EffectPool>();
            BindInHierarchy<ScoreView>();
            BindInHierarchy<PlayerView>();
            BindInHierarchy<PlayerDeathObserver>();

            Container
                .BindInterfacesAndSelfTo<ScoreSpawner>()
                .AsSingle();

            Container
                .BindInterfacesTo<ScoreEffectSpawner>()
                .AsSingle();

            Container
                .BindFactory<Score, ScoreFactory>()
                .FromComponentInNewPrefab(_scorePrefab);
        }

        private void RegisterObstacle<TImplementation>(TImplementation obstacle) where TImplementation : IPauseAction =>
            Container
                .Bind<IPauseAction>()
                .To<TImplementation>()
                .FromInstance(obstacle)
                .AsCached();

        private void BindInHierarchy<TImplementation>() where TImplementation : MonoBehaviour =>
            Container
                .Bind<TImplementation>()
                .FromComponentInHierarchy()
                .AsSingle();
    }
}