using CodeBase.Configs.Obstacle;
using CodeBase.Configs.Player;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfig _playerConfig;

    public override void InstallBindings()
    {
        Container
                .BindInstance(_playerConfig)
                .AsSingle();
    }
}
