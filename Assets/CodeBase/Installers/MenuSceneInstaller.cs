using CodeBase.UI.MainMenu;
using CodeBase.UI.Score;
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
            Container
                .Bind<ScoreView>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .BindInterfacesTo<StartGameButton>()
                .AsSingle()
                .WithArguments(_startButton)
                .NonLazy();

            Container
                 .Bind<LoadScreen>()
                 .FromComponentInHierarchy()
                 .AsSingle();
        }
    }
}