using System;
using JetBrains.Annotations;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.MainMenu
{
    [UsedImplicitly]
    public class StartGameButton : IInitializable, IDisposable
    {
        private const string SceneName = "GamePlay";
        private readonly Button _button;
        private readonly LoadScreen _loadScreen;

        public StartGameButton(Button button, LoadScreen loadScreen)
        {
            _button = button;
            _loadScreen = loadScreen;
        }

        void IInitializable.Initialize() =>
            _button.onClick.AddListener(OnButtonClicked);

        void IDisposable.Dispose() =>
            _button.onClick.RemoveListener(OnButtonClicked);

        private void OnButtonClicked() =>
            _loadScreen.Loading(SceneName);
    }
}