namespace UnitSkills.Features.Enemies
{
    using UnitSkills.Features.Combat;
    using UnitSkills.Features.Physics;
    using UnityEngine;

    /// <summary>
    /// Наносит периодический урон игроку в радиусе атаки
    /// </summary>
    public class EnemyDamageTrigger : AbstractGenericTrigger<IDamagableFacade>
    {
        [SerializeField, Min(1)] protected int damage = 1;
        [SerializeField, Min(0.1f)] protected float damageInterval = 1f;

        protected HealthController targetHealth = default;
        protected float nextDamageTime = 0f;

        /// <summary>
        /// Игрок вошёл в радиус атаки
        /// </summary>
        protected override void OnTriggerEnterSuccessfully(IDamagableFacade target)
        {
            targetHealth = target.GetFacadeModule<HealthController>();

            if (targetHealth != null)
            {
                nextDamageTime = 0f;
                TryDamage();
            }
        }

        /// <summary>
        /// Игрок вышел из радиуса атаки
        /// </summary>
        protected override void OnTriggerExitSuccessfully(IDamagableFacade target)
        {
            if (targetHealth != null)
            {
                targetHealth = null;
            }
        }

        protected virtual void Update() => TryDamage();

        /// <summary>
        /// Нанести урон с учетом интервала
        /// </summary>
        protected virtual void TryDamage()
        {
            if (targetHealth == null || Time.time < nextDamageTime)
            {
                return;
            }

            targetHealth.TakeDamage(damage);
            nextDamageTime = Time.time + damageInterval;
        }

        protected virtual void OnDisable() => targetHealth = null;
    }
}
