namespace UnitSkills.Features.SceneLoading
{
    using UnityEngine;

    /// <summary>
    /// Абстрактный класс для отображения прогресса загрузки сцены
    /// </summary>
    public abstract class AbstractLoadView : MonoBehaviour
    {
        protected virtual void OnEnable() => SceneLoadingController.onSceneProgressLoadChanged += OnUpdateProgressValue;
        protected virtual void OnDisable() => SceneLoadingController.onSceneProgressLoadChanged -= OnUpdateProgressValue;

        /// <summary>
        /// Вызывается при изменении прогресса загрузки сцены
        /// </summary>
        protected abstract void OnUpdateProgressValue(float value);
    }
}