
namespace UnitSkills.Features.Spawners
{
    using UnitSkills.Features.Enemies;
    using UnitSkills.Features.Installer;
    using UnityEngine;

    /// <summary>
    /// Контроллер спавна врагов
    /// </summary>
    public sealed class EnemiesController : FacadeProvider
    {
        [SerializeField] private Transform _enemySpawnPoint = default;
        [SerializeField] private BaseSpawner _spawner = default;
        [SerializeField, Min(0.1f)] private float _spawnTime = 5f;
        [SerializeField, Min(1)] private int _maxEnemies = 5;

        private Transform _target = default;
        private float _elapsed = 0f;

        protected override void OnFacadeInited()
        {
            _target = container.FacadeInstance.transform;
            _elapsed = 0f;
        }

        protected override void OnFacadeDisposed()
        {
            _target = null;
            _elapsed = 0f;

            if (_spawner != null)
            {
                _spawner.Clear();
            }
        }

        private void Update()
        {
            if (_target == null || _spawner == null)
            {
                return;
            }

            _elapsed += Time.deltaTime;

            if (_elapsed < _spawnTime ||
                _spawner.ActiveCount >= _maxEnemies)
            {
                return;
            }

            _elapsed = 0f;
            SpawnEnemy();
        }

        /// <summary>
        /// Создать врага и назначить ему цель
        /// </summary>
        private void SpawnEnemy()
        {
            SpawnItem item = _spawner.Spawn(_enemySpawnPoint);

            if (item == null)
            {
                return;
            }

            EnemyFacade enemy = item.GetComponent<EnemyFacade>();

            if (enemy == null)
            {
                _spawner.Despawn(item);
                return;
            }

            EnemyChaseController chase = enemy.GetFacadeModule<EnemyChaseController>();

            if (chase != null)
            {
                chase.SetTarget(_target);
            }
            else
            {
                _spawner.Despawn(item);
            }
        }
    }
}
