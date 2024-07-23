using CodeBase.Data;
using CodeBase.Infrastructure.Service;
using CodeBase.Logic;
using CodeBase.UI.Score;
using UnityEngine;
using Zenject;

namespace CodeBase.Configs.Installer
{
    [CreateAssetMenu(fileName = "GameSystemInstaller", menuName = "Installers/New GameSystemInstaller")]
    public class GameSystemInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerData>()
                .AsSingle();

            Container
                .BindInterfacesTo<StopActionController>()
                .AsSingle();

            Container
                .BindInterfacesTo<InputService>()
                .AsSingle();

            Container
                .Bind<ScoreWallet>()
                .AsSingle();

            Container
                .BindInterfacesTo<SaveScore>()
                .AsSingle();

            Container
                .BindInterfacesTo<ScoreController>()
                .AsSingle();
        }
    }
}