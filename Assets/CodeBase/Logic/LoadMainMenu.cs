using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Logic
{
    [UsedImplicitly]
    public class LoadMainMenu : MonoBehaviour
    {
        [SerializeField] private float _timeExpectation;

        private PlayerDeath _playerFacade;

        [Inject]
        public void Construct(PlayerDeath playerFacade)
        {
            _playerFacade = playerFacade;
        }

        private void OnEnable() =>
            _playerFacade.DiePlayer += LoadMenu;

        private void OnDisable() =>
            _playerFacade.DiePlayer -= LoadMenu;

        private void LoadMenu() =>
            StartCoroutine(Load("MainMenu"));

        private IEnumerator Load(string nameScene)
        {
            yield return new WaitForSeconds(_timeExpectation);
            SceneManager.LoadScene(nameScene);
        }
    }
}