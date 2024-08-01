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
            BindInterfaces<PlayerMovement>();
            BindInterfaces<StopActionController>();
            BindInterfaces<InputService>();
            BindInterfaces<SaveScore>();
            BindInterfaces<ScoreController>();

            Container
                .Bind<PlayerData>()
                .AsSingle();

            Container
                .Bind<ScoreWallet>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PlayerDeath>()
                .AsSingle();
        }

        public void BindInterfaces<T>()
        {
            Container
                .BindInterfacesTo<T>()
                .AsSingle();
        }
    }
}