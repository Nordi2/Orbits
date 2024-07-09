using CodeBase.Infrastructure.Factory;
using CodeBase.UI.Score;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [Inject] private IScoreFactory _scoreFactory;
        [SerializeField] private Transform _scoreSpawnPoint;

        public override void InstallBindings()
        {
            //RegisterScoreFactory();
            RegisterWallet();
            CreateScore();

        }

        private void CreateScore()
        {
            GameObject score = _scoreFactory.CreateScore(_scoreSpawnPoint.position);
            Container.BindInstance(score);
        }

        /* private void RegisterScoreFactory()
         {
             Container
                 .Bind<IScoreFactory>()
                 .To<ScoreFactory>()
                 .AsSingle();
         }*/

        private void RegisterWallet()
        {
            Container
                .Bind<ScoreWallet>()
                .AsSingle();
        }
    }
}