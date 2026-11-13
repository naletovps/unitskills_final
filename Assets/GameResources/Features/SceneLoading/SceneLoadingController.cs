namespace UnitSkills.Features.SceneLoading
{
    using System;
    using System.Collections;
    using UnitSkills.Features.Utils;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    /// <summary>
    /// Контроллер загрузки сцены
    /// </summary>
    public class SceneLoadingController : SingletonMonoBehaviour<SceneLoadingController>
    {
        public static event Action<float> onSceneProgressLoadChanged = delegate { };

        protected float loadingProgress = 0f;

        public float LoadingProgress
        {
            get => loadingProgress;
            protected set
            {
                if (loadingProgress != value)
                {
                    loadingProgress = value;

                    onSceneProgressLoadChanged.Invoke(loadingProgress);
                }
            }
        }

        [SerializeField] protected string startSceneName = "Menu";
        [SerializeField, Min(0.01f)] protected float loadingDelay = 3.0f;

        protected bool isLoading = false;

        protected void Start() => StartLoading(startSceneName);

        /// <summary>
        /// Начинает загрузку сцены
        /// </summary>
        public static void StartLoading(string sceneName)
        {
            if (Instance.isLoading)
            {
                return;
            }

            Instance.StartCoroutine(Instance.LoadingProcess(sceneName));
        }

        protected IEnumerator LoadingProcess(string sceneName)
        {
            isLoading = true;
            LoadingProgress = 0f;

            if (SceneManager.GetActiveScene().name != "Loading")
            {
                yield return SceneManager.LoadSceneAsync("Loading");
            }

            yield return Resources.UnloadUnusedAssets();

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = false;

            float elapsed = 0f;

            while (!asyncOperation.isDone && isActiveAndEnabled)
            {
                elapsed += Time.unscaledDeltaTime;

                LoadingProgress = MathF.Min(elapsed / loadingDelay, asyncOperation.progress / 0.9f);

                if (asyncOperation.progress >= 0.9f && elapsed > loadingDelay)
                {
                    LoadingProgress = 1f;
                    asyncOperation.allowSceneActivation = true;
                }
                
                yield return null;
            }

            isLoading = false;
        }
    }
}