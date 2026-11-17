using System.Collections.Generic;
using UnitSkills.Features.Facade;
using UnityEngine;

namespace UnitSkills.Features.Resources
{
    /// <summary>
    /// Контракт подбирания предметов
    /// </summary>
    public interface IPickupableFacade 
    {
        T GetFacadeModule<T>() where T : FacadeModule;
        G GetDataFacadeModule<G>() where G : DataFacadeModule;
    }
}