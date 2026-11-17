namespace UnitSkills.Features.Resources
{
    using UnitSkills.Features.Combat;
    using UnityEngine;

    /// <summary>
    /// Увеличивает здоровье
    /// </summary>
    public class HealthPickup : PickupItem
    {
        [SerializeField, Min(0)] protected int amount = 10;
        protected HealthModel healthModel = default;

        public override bool TryPickup(PlayerPickupReceiver receiver)
        {
            if (receiver.PlayerFacade == null)
            {
                return false;
            }

            healthModel = receiver.PlayerFacade.GetDataFacadeModule<HealthModel>();

            if (healthModel.Current >= healthModel.Max)
            {
                return false;
            }

            healthModel.Heal(amount);

            return true;
        }
    }
}