using System;
using CodeBase.Logic.PlayerLogic;
using CodeBase.UI.Score;
using JetBrains.Annotations;
using Zenject;

namespace CodeBase.Logic
{
    [UsedImplicitly]
    public class SaveScore : IInitializable, IDisposable
    {
        private readonly IPlayerFacade _playerFacade;
        private readonly ScoreWallet _scoreWallet;

        public SaveScore(IPlayerFacade playerFacade, ScoreWallet scoreWallet)
        {
            _playerFacade = playerFacade;
            _scoreWallet = scoreWallet;
        }

        void IInitializable.Initialize() =>
            _playerFacade.DiePlayer += SaveProgress;

        void IDisposable.Dispose() =>
            _playerFacade.DiePlayer -= SaveProgress;

        private void SaveProgress()
        {
            if (!SaveSystem.SaveProgress.IsSave)
            {
                SaveSystem.SaveProgress.SaveScore(_scoreWallet);
            }
        }
    }
}