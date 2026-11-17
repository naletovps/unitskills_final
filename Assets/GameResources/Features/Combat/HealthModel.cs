namespace UnitSkills.Features.Combat
{
    using System;
    using UnitSkills.Features.DataManagment;
    using UnitSkills.Features.Facade;
    using UnityEngine;

    /// <summary>
    /// Здоровье сущности на сцене
    /// </summary>
    [CreateAssetMenu(fileName = "New Health Model", menuName = "UnitSkills/Data/Health")]
    public class HealthModel : DataFacadeModule
    {
        /// <summary>
        /// Данные здоровья для сохранения
        /// </summary>
        [Serializable]
        public class HealthSaveData : IData
        {
            public int health;
        }

        /// <summary>
        /// Вызывается при изменении здоровья
        /// </summary>
        public event Action onHealthChanged = delegate { };

        /// <summary>
        /// Вызывается, когда заканчивается здоровье
        /// </summary>
        public event Action onDied = delegate { };

        /// <summary>
        /// Текущее количество здоровья
        /// </summary>
        public int Current 
        { 
            get => current;
            private set
            {
                if (current == value)
                {
                    return;
                }

                current = value;
                onHealthChanged.Invoke();
            }
        }

        /// <summary>
        /// Максимальное количество здоровья
        /// </summary>
        public int Max => maxHealth;

        /// <summary>
        /// Жива ли сущность
        /// </summary>
        public bool IsAlive => Current > 0;

        [SerializeField, Min(1)] protected int maxHealth = 3;
        protected int current = default;

        protected const string SaveKey = "HealthModel";

        protected virtual void Awake() => ResetHealth();

        public override void OnModuleInited()
        {
            if (DataManager.Instance == null)
            {
                return;
            }

            HealthSaveData data = DataManager.Instance.GetData(SaveKey,
                new HealthSaveData
                {
                    health = maxHealth
                });

            Current = data.health;
        }

        public override void OnModuleDisposed()
        {
            if (DataManager.Instance == null)
            {
                return;
            }

            HealthSaveData data = new HealthSaveData
            {
                health = Current
            };

            DataManager.Instance.SetData(SaveKey, data);
        }

        public void ResetHealth() => Current = maxHealth;

        public void Damage(int damage)
        {
            if (damage <= 0 || !IsAlive)
            {
                return;
            }

            Current = Mathf.Max(0, Current - damage);

            if (Current == 0)
            {
                onDied.Invoke();
            }
        }

        public void Heal(int amount)
        {
            if (amount <= 0 || !IsAlive)
            {
                return;
            }

            Current = Mathf.Min(Max, Current + amount);
        }
    }
}