namespace UnitSkills.Features.Spawners
{
    using UnityEngine;

    /// <summary>
    /// Класс объекта, созданный спавнером
    /// </summary>
    public class SpawnItem : MonoBehaviour
    {
        /// <summary>
        /// Ссылка на спавнер, который заспавнил объект
        /// </summary>
        public BaseSpawner Owner { get; private set; }

        /// <summary>
        /// Назначить ссылку на спавнер
        /// </summary>
        internal void SetOwner(BaseSpawner spawner) => Owner = spawner;

        /// <summary>
        /// Вызывается при спавне
        /// </summary>
        public virtual void OnSpawn() { }

        /// <summary>
        /// Вызывается при уничтожении
        /// </summary>
        public virtual void OnDespawn() { }

        /// <summary>
        /// Попросить свой спавнер убрать объект
        /// </summary>
        public void Despawn()
        {
            if (Owner != null)
            {
                Owner.Despawn(this);
            }
        }
    }
}
