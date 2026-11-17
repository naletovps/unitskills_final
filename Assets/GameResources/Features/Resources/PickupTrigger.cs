namespace UnitSkills.Features.Resources
{
    using UnitSkills.Features.Physics;
    using UnityEngine;

    /// <summary>
    /// Триггер на ресурсе
    /// </summary>
    [RequireComponent(typeof(PickupItem))]
    public class PickupTrigger : AbstractGenericTrigger<PlayerPickupReceiver>
    {
        [SerializeField] protected PickupItem item;

        protected virtual void Awake()
        {
            if (item == null)
            {
                item = GetComponent<PickupItem>();
            }
        }

        protected override void OnTriggerEnterSuccessfully(PlayerPickupReceiver receiver)
        {
            if (item.TryPickup(receiver))
            {
                item.Despawn();
            }
        }
    }
}
