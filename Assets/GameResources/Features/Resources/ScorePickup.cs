namespace UnitSkills.Features.Resources
{
    using UnitSkills.Features.Gameplay;
    using UnityEngine;

    /// <summary>
    /// Начисляет очки
    /// </summary>
    public class ScorePickup : PickupItem
    {
        [SerializeField, Min(0)] protected int amount = 10;
        protected ScoreModel scoreModel = default;

        public override bool TryPickup(IPickupableFacade facade)
        {
            if (facade == null)
            {
                return false;
            }

            scoreModel = facade.GetDataFacadeModule<ScoreModel>();
            scoreModel.Add(amount);

            return true;
        }
    }
}