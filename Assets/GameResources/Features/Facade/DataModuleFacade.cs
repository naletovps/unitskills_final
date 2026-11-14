namespace Unitskills.Features.Facade
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Дата модуля фасада
    /// </summary>
    public abstract class DataModuleFacade : ScriptableObject
    {
        /// <summary>
        /// Дата модуль инициализирован
        /// </summary>
        public event Action onModuleInited = delegate { };

        /// <summary>
        /// Дата Модуль деактивирован
        /// </summary>
        public event Action onModuleDisposed = delegate { };

        /// <summary>
        /// Корневой фасад данного модуля
        /// </summary>
        /// <value></value>
        public virtual AbstractFacade Facade
        {
            get => facade;
            set
            {
                facade = value;

                if (value == null)
                {
                    onModuleDisposed();
                    return;
                }

                onModuleInited();
            }
        }

        /// <summary>
        /// Идентификатор дата модуля
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
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            OnModuleDisposed();
            Facade = null;
        }

        /// <summary>
        /// Метод срабатывающий по факту инициализации модуля фасада
        /// </summary>
        public abstract void OnModuleInited();

        /// <summary>
        /// Метод срабатывающий по факту уничтожения фасада
        /// </summary>
        public virtual void OnModuleDisposed() { }
    }
}