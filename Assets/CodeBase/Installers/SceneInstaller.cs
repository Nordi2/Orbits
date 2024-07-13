using CodeBase.Infrastructure.Factory;
using CodeBase.Logic.ScoreLogic;
using Zenject;

namespace CodeBase.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [Inject] private IScoreFactory _scoreFactory;
        public ScoreFacade ScorePrefab;

        public override void InstallBindings()
        {
            RegisterSpawner();
            RegisterFactory();
        }

        

        private void RegisterFactory()
        {
            Container
                .BindFactory<Score, Factory>()
                .FromComponentInNewPrefab(ScorePrefab);
        }

        private void RegisterSpawner()
        {
            Container
                .BindInterfacesTo<ScoreSpawner>()
                .AsCached();
        }
    }
}