namespace UnitSkills.Features.Enemies
{
    using UnitSkills.Features.Physics;
    using UnityEngine;
    using UnityEngine.AI;

    public class EnemyChaseController : AbstractMovementController
    {
        public override Vector3 CurrentVelocity => agent.velocity;
        public NavMeshAgent Agent => agent;

        [SerializeField, Min(0.05f)] protected float updateInterval = 0.2f;
        [SerializeField] protected NavMeshAgent agent = default;

        protected Transform target = default;
        protected float nextUpdateTime = 0f;

        public override void OnModuleInited()
        {
            if (agent == null)
            {
                agent = GetComponent<NavMeshAgent>();
            }
        }

        public override void OnModuleDisposed()
        {
            SetTarget(null);
            agent = null;
        }

        /// <summary>
        /// Установить цель преследования
        /// </summary>
        public virtual void SetTarget(Transform newTarget)
        {
            target = newTarget;
            nextUpdateTime = 0f;

            if (target == null && agent.isOnNavMesh)
            {
                agent.ResetPath();
            }
        }

        /// <summary>
        /// Обновлять маршрут к цели
        /// </summary>
        protected virtual void Update()
        {
            if (target == null)
            {
                return;
            }

            if (Time.time < nextUpdateTime)
            {
                return;
            }

            nextUpdateTime = Time.time + updateInterval;
            agent.SetDestination(target.position);
        }
    }
}