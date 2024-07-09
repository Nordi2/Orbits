using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Infrastructure.Factory;
using Zenject;

namespace CodeBase.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisteredAssetProvider();
            RegisterScoreFactory();
        }
        private void RegisterScoreFactory()
        {
            Container
                .Bind<IScoreFactory>()
                .To<ScoreFactory>()
                .AsSingle();
        }
        private void RegisteredAssetProvider()
        {
            Container
                .Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();
        }
    }
}
