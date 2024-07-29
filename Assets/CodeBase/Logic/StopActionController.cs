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
        private readonly IInputService _inputService;
        private readonly IPauseAction[] _pauseActions;

        public StopActionController(
            IPauseAction[] pauseActions,
            IInputService inputService)
        {

            _pauseActions = pauseActions;
            _inputService = inputService;
        }

        void IInitializable.Initialize()
        {
            _inputService.OnClick += ClickFirstMouseButton;

            foreach (IPauseAction pauseAction in _pauseActions)
                pauseAction.StopAction();
        }

        void IDisposable.Dispose() =>
            _inputService.OnClick -= ClickFirstMouseButton;

        private void ClickFirstMouseButton()
        {
            foreach (IPauseAction pauseAction in _pauseActions)
                pauseAction.StartAction();

            _inputService.OnClick -= ClickFirstMouseButton;
        }
    }
}