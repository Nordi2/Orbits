using Assets.CodeBase.Logic.Player;
using System;
using Zenject;

namespace CodeBase.Logic
{
    public class PlayerDeath : IInitializable, IDisposable
    {
        private readonly PlayerView _playerView;
        private readonly PlayerDeathObserver _playerDeathObserver;

        public event Action DiePlayer;

        public PlayerDeath(PlayerDeathObserver playerDeathObserver, PlayerView playerView)
        {
            _playerDeathObserver = playerDeathObserver;
            _playerView = playerView;
        }

        void IInitializable.Initialize() =>
            _playerDeathObserver.TriggerEnter += CollisionWithAnObstacle;

        void IDisposable.Dispose() =>
            _playerDeathObserver.TriggerEnter -= CollisionWithAnObstacle;

        private void CollisionWithAnObstacle()
        {
            _playerView.PlayDeathEffect();
            DiePlayer?.Invoke();
        }
    }
}