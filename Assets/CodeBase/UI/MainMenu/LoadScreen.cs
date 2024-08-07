using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.UI.MainMenu
{
    public class LoadScreen : MonoBehaviour
    {
        private const float YieldSeconds = 2.2f;

        [SerializeField] private Slider _scale;

        public void Loading(string sceneName)
        {
            gameObject.SetActive(true);
            StartCoroutine(LoadAsync(sceneName));
        }

        private IEnumerator LoadAsync(string nameScene)
        {
            AsyncOperation loadAsync = SceneManager.LoadSceneAsync(nameScene);
            loadAsync.allowSceneActivation = false;

            while (!loadAsync.isDone)
            {
                _scale.value = loadAsync.progress;

                if (loadAsync.progress >= 0.9f && !loadAsync.allowSceneActivation)
                {
                    yield return new WaitForSeconds(YieldSeconds);
                    loadAsync.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}