namespace UnitSkills.Features.Resources
{
    using System.Collections.Generic;
    using UnitSkills.Features.Spawners;
    using UnityEngine;

    /// <summary>
    /// Контроллер спавна ресурсов на заданных точках
    /// </summary>
    public class ResourcesController : MonoBehaviour
    {
        [SerializeField] private List<BaseSpawner> _spawners = new();
        [SerializeField] private List<Transform> _spawnPoints = new();
        [SerializeField, Min(0.1f)] private float _spawnTime = 5f;

        private List<SpawnItem> _spawnedItems = new();
        private float _elapsed = 0f;

        private void Awake()
        {
            for (int i = 0; i < _spawnPoints.Count; i++)
            {
                _spawnedItems.Add(null);
            }
        }

        private void Start()
        {
            SpawnResources();
        }

        private void Update()
        {
            _elapsed += Time.deltaTime;

            if (_elapsed < _spawnTime)
            {
                return;
            }

            _elapsed = 0f;
            SpawnResources();
        }

        /// <summary>
        /// Создать случайные ресурсы на свободных точках
        /// </summary>
        private void SpawnResources()
        {
            if (_spawners.Count == 0)
            {
                return;
            }

            for (int i = 0; i < _spawnPoints.Count; i++)
            {
                if (_spawnPoints[i] == null)
                {
                    continue;
                }

                if (_spawnedItems[i] != null &&
                    _spawnedItems[i].Owner != null)
                {
                    continue;
                }

                int index = Random.Range(0, _spawners.Count);
                BaseSpawner spawner = _spawners[index];

                if (spawner == null)
                {
                    continue;
                }

                _spawnedItems[i] = spawner.Spawn(_spawnPoints[i]);
            }
        }
    }
}
