using CodeBase.UI.Score;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterWallet();
        }

        private void RegisterWallet()
        {
            Container
                .Bind<ScoreWallet>()
                .AsSingle();
        }
    }
}
