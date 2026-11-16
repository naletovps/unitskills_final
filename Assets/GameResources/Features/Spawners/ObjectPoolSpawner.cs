namespace UnitSkills.Features.Spawners
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Спавнер с повторным использованием объектов
    /// </summary>
    public class ObjectPoolSpawner : BaseSpawner
    {
        [SerializeField, Min(0)] protected int countPrewarm = 6;
        protected Queue<SpawnItem> available = new Queue<SpawnItem>();

        protected virtual void Awake()
        {
            for (int i = 0; i < countPrewarm; i++)
            {
                if (prefab == null)
                {
                    break;
                }

                SpawnItem item = Instantiate(prefab, transform);
                item.gameObject.SetActive(false);
                available.Enqueue(item);
            }
        }

        protected override SpawnItem CreateItem(Vector3 position, Quaternion rotation)
        {
            SpawnItem item = available.Count > 0 ? available.Dequeue() : Instantiate(prefab, transform);

            item.transform.SetParent(null);
            item.transform.SetPositionAndRotation(position, rotation);
            item.gameObject.SetActive(true);

            return item;
        }

        protected override void ReleaseItem(SpawnItem item)
        {
            if (item == null || available.Contains(item))
            {
                return;
            }

            item.gameObject.SetActive(false);
            item.transform.SetParent(transform);
            available.Enqueue(item);
        }
    }
}
