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
    public class StopActionController : IInitializable, IDisposable
    {
        private readonly PlayerMovement _playerMovement;
        private readonly IInputService _inputService;
        private readonly ScoreSpawner _scoreSpawner;
        private readonly Obstacle[] _obstacles;

        public StopActionController(
            Obstacle[] obstacles,
            ScoreSpawner scoreSpawner,
            PlayerMovement playerMovement,
            IInputService inputService)
        {
            _obstacles = obstacles;
            _scoreSpawner = scoreSpawner;
            _inputService = inputService;
            _playerMovement = playerMovement;
        }

        void IInitializable.Initialize()
        {
            _inputService.OnClick += ClickFirstMouseButton;
            _scoreSpawner.StopAction();

            foreach (Obstacle obstacle in _obstacles)
                obstacle.StopAction();

            _playerMovement.StopAction();
        }

        void IDisposable.Dispose() =>
            _inputService.OnClick -= ClickFirstMouseButton;

        private void ClickFirstMouseButton()
        {
            foreach (Obstacle obstacle in _obstacles)
                obstacle.StartAction();

            _scoreSpawner.StartAction();
            _playerMovement.StartAction();
            _inputService.OnClick -= ClickFirstMouseButton;
        }
    }
}