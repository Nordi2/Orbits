using CodeBase.Logic;
using CodeBase.Logic.ObstaclLogic;
using CodeBase.Logic.PlayerLogic;
using CodeBase.Logic.ScoreLogic;
using CodeBase.UI.Score;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _scorePrefab;
        [SerializeField] private Obstacle _obstacleFar;
        [SerializeField] private Obstacle _obstacleMiddle;
        [SerializeField] private Obstacle _obstacleClose;

        public override void InstallBindings()
        {
            RegisterObstacle(_obstacleClose);
            RegisterObstacle(_obstacleMiddle);
            RegisterObstacle(_obstacleFar);
            RegisterPlayer<IPlayerFacade, PlayerFacade>();

            Container
                .BindInterfacesAndSelfTo<ScoreSpawner>()
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
        }

        private void RegisterObstacle<T>(T obstacle) where T : IPause =>
            Container
                .Bind<T>()
                .FromInstance(obstacle)
                .AsCached();

        private void RegisterPlayer<T, TA>() where T : IPause where TA : T =>
            Container
                .Bind<T>()
                .To<TA>()
                .FromComponentInHierarchy()
                .AsSingle();
    }
}