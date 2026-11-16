namespace UnitSkills.Features.Spawners
{
    using System.Collections;
    using UnityEngine;

    /// <summary>
    /// Объект, автоматически исчезающий по таймеру
    /// </summary>
    public class TimedSpawnItem : SpawnItem
    {
        [SerializeField, Min(0f)] protected float lifetime = 4f;
        protected Coroutine lifetimeCoroutine;

        public override void OnSpawn()
        {
            OnDespawn();

            lifetimeCoroutine = StartCoroutine(LifetimeProcess());
        }

        public override void OnDespawn()
        {
            if (lifetimeCoroutine != null)
            {
                StopCoroutine(lifetimeCoroutine);
                lifetimeCoroutine = null;
            }
        }

        protected virtual IEnumerator LifetimeProcess()
        {
            yield return new WaitForSeconds(lifetime);

            lifetimeCoroutine = null;
            Despawn();
        }
    }
}
