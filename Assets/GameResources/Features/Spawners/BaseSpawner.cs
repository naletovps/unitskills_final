namespace UnitSkills.Features.Spawners
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Базовый класс спавнера
    /// </summary>
    public class BaseSpawner : MonoBehaviour
    {
        /// <summary>
        /// Вызывается при спавне объекта
        /// </summary>
        public event Action<SpawnItem> onSpawned = delegate { };

        /// <summary>
        /// Вызывается при уничтожении объекта
        /// </summary>
        public event Action<SpawnItem> onDespawned = delegate { };

        /// <summary>
        /// Количество активных объектов
        /// </summary>
        public int ActiveCount => activeItems.Count;

        [SerializeField] protected SpawnItem prefab;
        protected List<SpawnItem> activeItems = new List<SpawnItem>();

        /// <summary>
        /// Спавнит объект на месте спавна
        /// </summary>
        public virtual SpawnItem Spawn() => Spawn(transform.position, transform.rotation);

        /// <summary>
        /// Спавнит объекат в конкретной точке
        /// </summary>
        public virtual SpawnItem Spawn(Transform point)
        {
            if (point == null)
            {
                return null;
            }

            return Spawn(point.position, point.rotation);
        }

        /// <summary>
        /// Спавнит объект в заданной позиции и поворотом
        /// </summary>
        public virtual SpawnItem Spawn(Vector3 position, Quaternion rotation)
        {
            SpawnItem item = CreateItem(position, rotation);

            item.SetOwner(this);
            activeItems.Add(item);
            item.OnSpawn();
            onSpawned.Invoke(item);

            return item;
        }

        /// <summary>
        /// Метод создания объекта
        /// </summary>
        protected virtual SpawnItem CreateItem(Vector3 position, Quaternion rotation) => Instantiate(prefab, position, rotation);

        public virtual void Despawn(SpawnItem item)
        {
            if (item == null || item.Owner != this || !activeItems.Remove(item))
            {
                return;
            }

            item.OnDespawn();
            onDespawned.Invoke(item);
            ReleaseItem(item);
            item.SetOwner(null);
        }

        /// <summary>
        /// Метод уничтожения объекта
        /// </summary>
        protected virtual void ReleaseItem(SpawnItem item) => Destroy(item.gameObject);

        /// <summary>
        /// Убрать все активные объекты спавнера
        /// </summary>
        public void Clear()
        {
            while (activeItems.Count > 0)
            {
                Despawn(activeItems[activeItems.Count - 1]);
            }
        }
    }
}
