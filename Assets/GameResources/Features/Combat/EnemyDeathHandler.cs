namespace UnitSkills.Features.Enemies
{
    using UnitSkills.Features.Combat;
    using UnitSkills.Features.Facade;
    using UnitSkills.Features.Spawners;
    using UnityEngine;

    /// <summary>
    /// Обрабатывает смерть врага
    /// </summary>
    public class EnemyDeathHandler : FacadeModule
    {
        protected HealthController healthController = default;
        protected SpawnItem spawnItem = default;

        public override void OnModuleInited()
        {
            healthController = Facade.GetFacadeModule<HealthController>();
            spawnItem = Facade.GetComponent<SpawnItem>();

            if (healthController != null)
            {
                healthController.onDied += OnDied;
            }
        }

        public override void OnModuleDisposed()
        {
            if (healthController != null)
            {
                healthController.onDied -= OnDied;
                healthController = null;
            }

            spawnItem = null;
        }

        /// <summary>
        /// Удалить врага после смерти
        /// </summary>
        protected virtual void OnDied()
        {
            if (spawnItem == null || spawnItem.Owner == null)
            {
                return;
            }

            spawnItem.Owner.Despawn(spawnItem);
        }
    }
}
