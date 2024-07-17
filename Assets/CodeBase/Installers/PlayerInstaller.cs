using CodeBase.Configs.Player;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;

        public override void InstallBindings()
        {
            RegisterPlayerConfig();
        }

        #region Register Method

        private void RegisterPlayerConfig() =>
            Container
                .BindInstance(_playerConfig)
                .AsSingle();

        #endregion
    }
}