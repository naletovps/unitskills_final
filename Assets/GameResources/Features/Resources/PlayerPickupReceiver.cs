namespace UnitSkills.Features.Resources
{
    using UnitSkills.Features.Facade;

    /// <summary>
    /// Получатель подбираемых предметов
    /// </summary>
    public class PlayerPickupReceiver : FacadeModule
    {
        public AbstractFacade PlayerFacade { get; private set; }

        public override void OnModuleInited() => PlayerFacade = Facade;
    }
}