namespace UnitSkills.Features.Installer
{
    using UnityEngine;

    /// <summary>
    /// Базовый класс для компонентов, использующих фасад персонажа
    /// </summary>
    public abstract class FacadeProvider : MonoBehaviour
    {
        [SerializeField] protected FacadeContainer container = default;

        protected virtual void OnEnable()
        {
            container.onCharacterInited += OnFacadeInited;
            container.onCharacterDisposed += OnFacadeDisposed;

            if (container.FacadeInstance != null)
            {
                OnFacadeInited();
            }
        }

        protected virtual void OnDisable()
        {
            container.onCharacterInited -= OnFacadeInited;
            container.onCharacterDisposed -= OnFacadeDisposed;
        }

        protected abstract void OnFacadeInited();
        protected virtual void OnFacadeDisposed() { }
    }
}