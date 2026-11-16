namespace UnitSkills.Features.Weapons
{
    using UnitSkills.Features.Facade;
    using UnitSkills.Features.Physics;
    using UnitSkills.Features.Shooting;
    using UnitSkills.Features.Spawners;
    using UnityEngine;

    /// <summary>
    /// Стрельба снежками
    /// </summary>
    public class SnowballShooter : FacadeModule
    {
        [SerializeField] protected ObjectPoolSpawner projectilePool;
        [SerializeField] protected Transform shootPoint;
        protected ShootingController shootingController;

        public override void OnModuleInited()
        {
            shootingController = Facade.GetFacadeModule<ShootingController>();
            shootingController.onShotPerformed += Shoot;
        }

        public override void OnModuleDisposed() => shootingController.onShotPerformed -= Shoot;

        protected virtual void Shoot()
        {
            SpawnItem item = projectilePool.Spawn(shootPoint);

            if (item == null)
            {
                return;
            }

            if (item.TryGetComponent(out ProjectileImpulse impulse))
            {
                impulse.Apply(shootPoint.forward);
            }
        }
    }
}
