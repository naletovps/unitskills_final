namespace UnitSkills.Features.Resources
{
    using UnitSkills.Features.Shooting;

    /// <summary>
    /// Пополняет полный запас патронов
    /// </summary>
    public class AmmoPickup : PickupItem
    {
        protected AmmoModel ammoModel = default;

        public override bool TryPickup(IPickupableFacade facade)
        {
            if (facade == null)
            {
                return false;
            }

            ammoModel = facade.GetDataFacadeModule<AmmoModel>();

            if (ammoModel.AmmoCount >= ammoModel.Capacity)
            {
                return false;
            }

            ammoModel.ResetAmmo();

            return true;
        }
    }
}