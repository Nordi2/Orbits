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
            Container.BindInterfacesTo<ScoreController>().AsSingle();
        }

        #region Register Method

        private void RegisterSaveScore() =>
            Container
                .BindInterfacesTo<SaveScore>()
                .AsSingle();

        private void RegisterStopAction() =>
            Container
                .BindInterfacesTo<StopActionController>()
                .AsCached();

        private void RegisterInput() =>
            Container
                .BindInterfacesTo<InputService>()
                .AsSingle();

        private void RegisterWallet() =>
            Container
                .Bind<ScoreWallet>()
                .AsSingle();

        #endregion
    }
}