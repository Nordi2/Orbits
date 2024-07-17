using CodeBase.UI.MainMenu;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Installers
{
    public class MenuSceneInstaller : MonoInstaller
    {
        [SerializeField] private Button _startButton;

        public override void InstallBindings()
        {
            RegisterStartButton();
            RegisterLoadScreen();
        }

        #region Register Method

        private void RegisterLoadScreen() =>
            Container
                .Bind<LoadScreen>()
                .FromComponentInHierarchy()
                .AsSingle();

        private void RegisterStartButton() =>
            Container
                .BindInterfacesTo<StartGameButton>()
                .AsSingle()
                .WithArguments(_startButton)
                .NonLazy();

        #endregion
    }
}