using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Service;
using CodeBase.Logic.ScoreLogic;
using CodeBase.UI.Score;
using Zenject;

namespace CodeBase.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [Inject] private IScoreFactory _scoreFactory;
        public ScoreFacade ScorePrefab;

        public override void InstallBindings()
        {
            RegisterInput();
            RegisterWallet();
            Container.BindInterfacesTo<ScoreSpawner>().AsSingle();
            Container.BindFactory<Score, Factory>().FromComponentInNewPrefab(ScorePrefab);
        }

        private void RegisterInput()
        {
            Container
                .Bind<IInputService>()
                .To<InputService>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void RegisterWallet()
        {
            Container
                .Bind<ScoreWallet>()
                .AsSingle();
        }
    }
}