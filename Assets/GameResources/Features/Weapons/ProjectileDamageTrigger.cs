namespace UnitSkills.Features.Weapons
{
    using UnitSkills.Features.Combat;
    using UnitSkills.Features.Physics;
    using UnitSkills.Features.Spawners;
    using UnityEngine;

    [RequireComponent(typeof(SpawnItem))]
    public class ProjectileDamageTrigger : AbstractGenericTrigger<IDamagableFacade>
    {
        [SerializeField] protected int damage = 10;
        [SerializeField] protected SpawnItem spawnItem = default;

        private void Awake()
        {
            if (spawnItem == null)
            {
                spawnItem = GetComponent<SpawnItem>();
            }
        }

        protected override void OnTriggerEnterSuccessfully(IDamagableFacade facade)
        {
            facade.GetDataFacadeModule<HealthModel>().Damage(damage);
            spawnItem.Despawn();
        }

        protected override void OnTriggerEnterFail()
        {
            spawnItem.Despawn();
        }
    }
}