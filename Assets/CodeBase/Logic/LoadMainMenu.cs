using System;
using System.Collections;
using CodeBase.Logic.PlayerLogic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Logic
{
    public class LoadMainMenu : IInitializable, IDisposable
    {
        private float _timeExpectation;
        private readonly IPlayerFacade _playerFacade;

        public LoadMainMenu(IPlayerFacade playerFacade)
        {
            _playerFacade = playerFacade;
        }

        public void Initialize() =>
            _playerFacade.DiePlayer += LoadMenu;

        public void Dispose() =>
            _playerFacade.DiePlayer -= LoadMenu;

        private void LoadMenu()
        {
            SceneManager.LoadScene("MainMenu");
            //StartCoroutine(Load("MainMenu", _timeExpectation));
        }

        private IEnumerator Load(string name, float time)
        {
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(name);
        }
    }
}