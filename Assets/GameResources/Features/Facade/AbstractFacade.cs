namespace Unitskills.Features.Facade
{
    using System.Collections.Generic;
    using UnityEngine;
    using System;

    /// <summary>
    /// Асбтрактный фасад с набором абстрактных модулей
    /// </summary>
    public abstract class AbstractFacade : MonoBehaviour
    {
        /// <summary>
        /// Фасад инициализирован
        /// </summary>
        public event Action onFacadeInited = delegate { };

        /// <summary>
        /// Фасад деактивирован
        /// </summary>
        public event Action onFacadeDeactivated = delegate { };

        /// <summary>
        /// Список модулей фасада (контроллеры / MonoBehaviour классы)
        /// </summary>
        public IReadOnlyList<ModuleFacade> Modules => modules;

        /// <summary>
        /// Список моделей и дат фасада (скриптуемые объекты)
        /// </summary>
        public IReadOnlyList<DataModuleFacade> DataModules => dataModuleFacades;

        /// <summary>
        /// Идентификатор фасада
        /// </summary>
        public string Id => id;

        /// <summary>
        /// Получить модуль по типу
        /// </summary>
        /// <typeparam name="T">Тип модуля</typeparam>
        /// <returns>Целевой модуль</returns>
        public T GetModuleFacade<T>() where T : ModuleFacade
        {
            T module = (T)modules.Find(x => x is T);

            if (!module)
            {
                Debug.LogError($"Модуль {nameof(T)} не найден");
            }

            return module;
        }

        /// <summary>
        /// Получить список функциональных модулей (MB)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<ModuleFacade> GetModules<T>() where T : ModuleFacade => modules.FindAll(x => x is T);

        /// <summary>
        /// Получить список модулей
        /// </summary>
        /// <typeparam name="G"></typeparam>
        /// <returns></returns>
        public List<DataModuleFacade> GetDataModuleFacades<G>() where G : DataModuleFacade => dataModuleFacades.FindAll(x => x is G);

        /// <summary>
        /// Получить модуль по типу
        /// </summary>
        /// <typeparam name="T">Тип модуля</typeparam>
        /// <returns>Целевой модуль</returns>
        public G GetDataModule<G>() where G : DataModuleFacade
        {
            G module = (G)dataModuleFacades.Find(x => x is G);

            if (!module)
            {
                Debug.LogError($"Модуль {nameof(G)} не найден");
            }

            return module;
        }

        [SerializeField] protected string id = string.Empty;
        [SerializeField] protected List<ModuleFacade> modules = new List<ModuleFacade>();
        [SerializeField] protected List<DataModuleFacade> dataModuleFacades = new List<DataModuleFacade>();

        protected virtual void OnEnable()
        {
            modules.ForEach(x => x.Initialize(this));
            dataModuleFacades.ForEach(x => x.Initialize(this));

            onFacadeInited.Invoke();
        }

        protected virtual void OnDisable()
        {
            dataModuleFacades.ForEach(x => x.Dispose());

            onFacadeDeactivated.Invoke();
        }
    }
}