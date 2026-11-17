namespace UnitSkills.Features.Physics
{
    using UnitSkills.Features.Facade;
    using UnityEngine;

    /// <summary>
    /// Абстрактный класс перемещения
    /// </summary>
    public abstract class AbstractMovementController : FacadeModule
    {
        public abstract Vector3 CurrentVelocity { get; }
    }
}