using CodeBase.Logic;
using UnityEngine;
using Zenject;

namespace CodeBase.Configs.Installer
{
    [CreateAssetMenu(fileName = "MenuSystemInstaller", menuName = "Installers/New MenuSystemInstaller")]
    public class MenuSystemInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<LoadScore>()
                .AsSingle()
                .NonLazy();
        }
    }
}