namespace UnitSkills.Features.Character
{
    using UnitSkills.Features.Combat;
    using UnitSkills.Features.Facade;
    using UnitSkills.Features.Resources;

    /// <summary>
    /// Фасад персонажа
    /// Является точкой доступа к основным его метрикам
    /// </summary>
    public class CharacterFacade : AbstractFacade, IPickupableFacade, IDamagableFacade { }
}