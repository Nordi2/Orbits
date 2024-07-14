using CodeBase.Infrastructure.Factory;
using CodeBase.Logic;
using CodeBase.Logic.ObstaclLogic;
using CodeBase.Logic.PlayerLogic;
using CodeBase.Logic.ScoreLogic;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [Inject] private IScoreFactory _scoreFactory;
        public ScoreFacade ScorePrefab;

        [SerializeField] private ObstacleFacade _obstacleFar;
        [SerializeField] private ObstacleFacade _obstacleMiddle;
        [SerializeField] private ObstacleFacade _obstacleClose;

        public override void InstallBindings()
        {
            RegisterObstacle<IObstacleFacade>(_obstacleClose);
            RegisterObstacle<IObstacleFacade>(_obstacleMiddle);
            RegisterObstacle<IObstacleFacade>(_obstacleFar);
            RegisterPlayer<IPlayerFacade, PlayerFacade>();
            RegisterSpawner();
            RegisterFactory();
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

        private void RegisterFactory() =>
            Container
                .BindFactory<Score, Factory>()
                .FromComponentInNewPrefab(ScorePrefab);

        private void RegisterSpawner() =>
            Container
                .BindInterfacesAndSelfTo<ScoreSpawner>()
                .AsCached();
    }
}