using System;
using CodeBase.Data;
using CodeBase.Logic.PlayerLogic;
using CodeBase.UI.Score;
using JetBrains.Annotations;
using Zenject;
using Services= CodeBase.Infrastructure.Service;

namespace CodeBase.Logic
{
    [UsedImplicitly]
    public class SaveScore : IInitializable, IDisposable
    {
        private readonly PlayerDeath _playerDeath;
        private readonly ScoreWallet _scoreWallet;
        private readonly PlayerData _playerData;

        public SaveScore(PlayerDeath playerdeath, ScoreWallet scoreWallet, PlayerData playerData)
        {
            _playerData = playerData;
            _playerDeath = playerdeath;
            _scoreWallet = scoreWallet;
        }

        void IInitializable.Initialize() =>
            _playerDeath.DiePlayer += SaveProgress;

        void IDisposable.Dispose() =>
            _playerDeath.DiePlayer -= SaveProgress;

        private void SaveProgress()
        {
            if (_playerData.Score < _scoreWallet.Score)
            {
                _playerData.NewRecord(_scoreWallet.Score);
                Services.SaveProgress.SaveScore(_playerData);
            }
        }
    }
}