using System;
using CodeBase.Infrastructure.Service;
using CodeBase.Logic.ObstaclLogic;
using CodeBase.Logic.PlayerLogic;
using CodeBase.Logic.ScoreLogic;
using JetBrains.Annotations;
using Zenject;

namespace CodeBase.Logic
{
    [UsedImplicitly]
    public class StopActionObject : IInitializable, IDisposable
    {
        private IPlayerFacade _playerMovement;
        private IInputService _inputService;
        private ScoreSpawner _scoreSpawner;
        private IObstacleFacade[] _obstacles;

        public StopActionObject(
            IObstacleFacade[] obstacles,
            ScoreSpawner scoreSpawner,
            IPlayerFacade playerMovement,
            IInputService inputService)
        {
            _obstacles = obstacles;
            _scoreSpawner = scoreSpawner;
            _inputService = inputService;
            _playerMovement = playerMovement;
        }

        void IInitializable.Initialize()
        {
            _inputService.OnClickFirsrMouseButton += ClickFirstMouseButton;
            _scoreSpawner.StopAction();
            
            foreach (var obstacle in _obstacles)
                obstacle.StopAction();
            
            _playerMovement.StopAction();
        }

        void IDisposable.Dispose() =>
            _inputService.OnClickFirsrMouseButton -= ClickFirstMouseButton;

        private void ClickFirstMouseButton()
        {
            foreach (var obstacle in _obstacles)
                obstacle.StartAction();
            
            _scoreSpawner.StartAction();
            _playerMovement.StartAction();
            _inputService.OnClickFirsrMouseButton -= ClickFirstMouseButton;
        }
    }
}