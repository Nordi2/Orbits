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

        private PlayerDeath _playerDeath;

        [Inject]
        public void Construct(PlayerDeath playerDeath)
        {
            _playerDeath = playerDeath;
        }

        private void OnEnable() =>
            _playerDeath.DiePlayer += LoadMenu;

        private void OnDisable() =>
            _playerDeath.DiePlayer -= LoadMenu;

        private void LoadMenu() =>
            StartCoroutine(Load("MainMenu"));

        private IEnumerator Load(string nameScene)
        {
            yield return new WaitForSeconds(_timeExpectation);
            SceneManager.LoadScene(nameScene);
        }
    }
}