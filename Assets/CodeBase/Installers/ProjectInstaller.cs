using CodeBase.Configs;
using CodeBase.Configs.Player;
using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Infrastructure.Factory;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        public override void InstallBindings()
        {
            RegisterPlayerConfig();
            RegisteredAssetProvider();
            RegisterScoreFactory();
        }

        private void RegisterPlayerConfig()
        {
            Container
                .BindInstance(_playerConfig)
                .AsSingle();
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
