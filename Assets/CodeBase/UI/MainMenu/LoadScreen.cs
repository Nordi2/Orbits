using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.UI.MainMenu
{
    public class LoadScreen : MonoBehaviour
    {
        public LoadingScreen LoadingScreen;
        public Slider scale;

        public void Loading(string sceneName)
        {
            LoadingScreen.gameObject.SetActive(true);
            StartCoroutine(LoadAsync(sceneName));
        }

        private IEnumerator LoadAsync(string nameScene)
        {
            AsyncOperation loadAsync = SceneManager.LoadSceneAsync(nameScene);
            loadAsync.allowSceneActivation = false;

            while (!loadAsync.isDone)
            {
                scale.value = loadAsync.progress;

                if (loadAsync.progress >= 0.9f && !loadAsync.allowSceneActivation)
                {
                    yield return new WaitForSeconds(2.2f);
                    loadAsync.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}