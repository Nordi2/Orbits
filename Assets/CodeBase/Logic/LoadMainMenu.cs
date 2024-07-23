using System.Collections;
using CodeBase.Logic.PlayerLogic;
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
            StartCoroutine(Load("MainMenu", _timeExpectation));

        private IEnumerator Load(string nameScene, float time)
        {
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(nameScene);
        }
    }
}