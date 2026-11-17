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

        public override bool TryPickup(PlayerPickupReceiver receiver)
        {
            if (receiver.PlayerFacade == null)
            {
                return false;
            }

            scoreModel = receiver.PlayerFacade.GetDataFacadeModule<ScoreModel>();
            scoreModel.Add(amount);

            return true;
        }
    }
}