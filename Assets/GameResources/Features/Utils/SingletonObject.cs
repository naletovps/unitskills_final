namespace UnitSkills.Features.Utils
{
    using UnityEngine;

    /// <summary>
    /// Обеспечивает существование единственного экземпляра объекта на сцене
    /// </summary>
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        /// <summary>
        /// Текущий экземпляр синглтона
        /// </summary>
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);

                return;
            }

            Instance = (T)this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }

        protected virtual void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}