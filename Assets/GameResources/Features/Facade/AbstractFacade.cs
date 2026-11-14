namespace UnitSkills.Features.Facade
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
        public IReadOnlyList<FacadeModule> Modules => modules;

        /// <summary>
        /// Список моделей и дат фасада (скриптуемые объекты)
        /// </summary>
        public IReadOnlyList<DataFacadeModule> DataModules => dataModules;

        /// <summary>
        /// Получить модуль по типу
        /// </summary>
        /// <typeparam name="T">Тип модуля</typeparam>
        /// <returns>Целевой модуль</returns>
        public T GetFacadeModule<T>() where T : FacadeModule
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
        public List<FacadeModule> GetModules<T>() where T : FacadeModule => modules.FindAll(x => x is T);

        /// <summary>
        /// Получить список модулей
        /// </summary>
        /// <typeparam name="G"></typeparam>
        /// <returns></returns>
        public List<DataFacadeModule> GetDataFacadeModules<G>() where G : DataFacadeModule => dataModules.FindAll(x => x is G);

        /// <summary>
        /// Получить модуль по типу
        /// </summary>
        /// <typeparam name="T">Тип модуля</typeparam>
        /// <returns>Целевой модуль</returns>
        public G GetDataModule<G>() where G : DataFacadeModule
        {
            G module = (G)dataModules.Find(x => x is G);

            if (!module)
            {
                Debug.LogError($"Модуль {nameof(G)} не найден");
            }

            return module;
        }

        [SerializeField] protected List<FacadeModule> modules = new List<FacadeModule>();
        [SerializeField] protected List<DataFacadeModule> dataModules = new List<DataFacadeModule>();

        protected virtual void OnEnable()
        {
            modules.ForEach(x => x.Initialize(this));
            dataModules.ForEach(x => x.Initialize(this));

            onFacadeInited.Invoke();
        }

        protected virtual void OnDisable()
        {
            dataModules.ForEach(x => x.Dispose());

            onFacadeDeactivated.Invoke();
        }
    }
}