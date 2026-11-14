namespace Unitskills.Features.Facade
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Функциональный модуль фасада, должен располагаться на самом фасаде или в child gameObjects
    /// </summary>
    public abstract class ModuleFacade : MonoBehaviour
    {
        /// <summary>
        /// Модуль инициализирован
        /// </summary>
        public event Action onModuleInited = delegate { };

        /// <summary>
        /// Фасад модуля
        /// </summary>
        /// <value></value>
        public virtual AbstractFacade Facade
        {
            get => facade;
            set
            {
                facade = value;
                onModuleInited();
            }
        }

        /// <summary>
        /// Идентификатор модуля
        /// </summary>
        public string Id => id;

        [SerializeField] protected string id = string.Empty;
        [SerializeField] protected AbstractFacade facade = default;

        /// <summary>
        /// Инициализация фасада
        /// </summary>
        /// <param name="_facade"></param>
        public void Initialize(AbstractFacade _facade)
        {
            Facade = _facade;
            OnModuleInited();
        }

        /// <summary>
        /// Метод срабатывающий по факту инициализации модуля фасада
        /// </summary>
        public abstract void OnModuleInited();

        /// <summary>
        /// Метод срабатывающий по факту уничтожения модуля фасада
        /// </summary>
        public virtual void OnModuleDisposed() { }
    }
}