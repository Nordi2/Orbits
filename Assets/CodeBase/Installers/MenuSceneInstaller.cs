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
            Container.BindInterfacesTo<StartGameButton>().AsSingle()
                .WithArguments(_startButton).NonLazy();
            Container.Bind<LoadScreen>().FromComponentInHierarchy().AsSingle();
        }
    }
}