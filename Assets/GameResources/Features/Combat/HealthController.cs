namespace UnitSkills.Features.Combat
{
    using System;
    using UnitSkills.Features.Facade;

    /// <summary>
    /// Контроллер здоровья
    /// </summary>
    public class HealthController : FacadeModule
    {
        /// <summary>
        /// Персонаж умер
        /// </summary>
        public event Action onDied = delegate { };

        protected HealthModel healthModel = default;

        public override void OnModuleInited()
        {
            healthModel = Facade.GetDataFacadeModule<HealthModel>();
            healthModel.onDied += OnDied;
        }

        public override void OnModuleDisposed()
        {
            if (healthModel != null)
            {
                healthModel.onDied -= OnDied;
                healthModel = null;
            }
        }

        /// <summary>
        /// Нанести урон
        /// </summary>
        public virtual void TakeDamage(int amount)
        {
            if (healthModel == null || !healthModel.IsAlive)
            {
                return;
            }

            healthModel.Damage(amount);
        }

        /// <summary>
        /// Восстановить здоровье
        /// </summary>
        public virtual void Heal(int amount)
        {
            if (healthModel == null || !healthModel.IsAlive)
            {
                return;
            }

            healthModel.Heal(amount);
        }

        /// <summary>
        /// Обработка смерти
        /// </summary>
        protected virtual void OnDied()
        {
            onDied.Invoke();
        }
    }
}
