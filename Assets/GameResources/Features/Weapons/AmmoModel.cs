namespace UnitSkills.Features.Shooting
{
    using System;
    using UnitSkills.Features.DataManagment;
    using UnitSkills.Features.Facade;
    using UnityEngine;

    /// <summary>
    /// Модель патронов
    /// </summary>
    [CreateAssetMenu(fileName = "New Ammo Model", menuName = "UnitSkills/Data/Ammo")]
    public class AmmoModel : DataFacadeModule
    {
        /// <summary>
        /// Данные патронов для сохранения
        /// </summary>
        [Serializable]
        private class AmmoSaveData : IData
        {
            public int ammoCount;
        }

        /// <summary>
        /// Количество патронов изменилось
        /// </summary>
        public event Action onAmmoCountChanged = delegate { };

        /// <summary>
        /// Текущее количество патронов
        /// </summary>
        public int AmmoCount
        {
            get => ammoCount;
            set
            {
                if (ammoCount != value)
                {
                    ammoCount = value;
                    onAmmoCountChanged.Invoke();
                }
            }
        }

        /// <summary>
        /// Вместимость оружия
        /// </summary>
        public int Capacity => capacity;

        [SerializeField, Min(0)] protected int ammoCount = default;
        [SerializeField, Min(0)] protected int capacity = 6;

        private const string SaveKey = "AmmoModel";

        public override void OnModuleInited()
        {
            if (DataManager.Instance == null)
            {
                return;
            }

            AmmoSaveData data = DataManager.Instance.GetData(SaveKey,   
                new AmmoSaveData 
                {
                    ammoCount = Capacity
                });

            AmmoCount = data.ammoCount;
        }

        public override void OnModuleDisposed()
        {
            if (DataManager.Instance == null)
            {
                return;
            }

            AmmoSaveData data = new AmmoSaveData
            {
                ammoCount = AmmoCount
            };

            DataManager.Instance.SetData(SaveKey, data);
        }

        /// <summary>
        /// Восстанавливает начальное количество патронов
        /// </summary>
        public void ResetAmmo() => AmmoCount = Capacity;
    }
}
