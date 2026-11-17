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

        public override bool TryPickup(IPickupableFacade facade)
        {
            if (facade == null)
            {
                return false;
            }

            healthModel = facade.GetDataFacadeModule<HealthModel>();

            if (healthModel.Current >= healthModel.Max)
            {
                return false;
            }

            healthModel.Heal(amount);

            return true;
        }
    }
}