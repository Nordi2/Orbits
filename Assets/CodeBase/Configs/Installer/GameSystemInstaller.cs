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
            RegisterStopAction();
            RegisterInput();
            RegisterWallet();
            RegisterSaveScore();
            RegisterLoadMainMenu();
        }

        private void RegisterLoadMainMenu()
        {
            Container
                .BindInterfacesTo<LoadMainMenu>()
                .AsCached();
        }

        private void RegisterSaveScore()
        {
            Container
                .BindInterfacesTo<SaveScore>()
                .AsCached();
        }

        private void RegisterStopAction()
        {
            Container
                .BindInterfacesTo<StopActionObject>()
                .AsCached();
        }

        private void RegisterInput()
        {
            Container
                .BindInterfacesTo<InputService>()
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