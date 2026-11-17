using System.Collections.Generic;
using UnitSkills.Features.Facade;

namespace UnitSkills.Features.Combat
{
    /// <summary>
    /// Контракт на получение урона
    /// </summary>
    public interface IDamagableFacade 
    {
        T GetFacadeModule<T>() where T : FacadeModule;
        G GetDataFacadeModule<G>() where G : DataFacadeModule;
    }
}