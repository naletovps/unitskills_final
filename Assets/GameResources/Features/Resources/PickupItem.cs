namespace UnitSkills.Features.Resources
{
    using UnitSkills.Features.Spawners;

    /// <summary>
    /// Абстрактный класс подбираемого ресурса
    /// </summary>
    public abstract class PickupItem : SpawnItem
    {
        /// <summary>
        /// Пытаемся поднять предмет
        /// </summary>
        public abstract bool TryPickup(PlayerPickupReceiver receiver);
    }
}