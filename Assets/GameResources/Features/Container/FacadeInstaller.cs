namespace UnitSkills.Features.Installer
{
    using UnitSkills.Features.Facade;
    using UnityEngine;

    /// <summary>
    /// Регистрирует персонажа в контейнере
    /// </summary>
    public sealed class FacadeInstaller : MonoBehaviour
    {
        [SerializeField] private AbstractFacade _facade = default;
        [SerializeField] private FacadeContainer _container = default;

        /// <summary>
        /// Регистрирует персонажа
        /// </summary>
        public void Install(AbstractFacade facade)
        {
            _facade = facade;
            _container.FacadeInstance = _facade;
        }

        private void OnDestroy()
        {
            if (_container.FacadeInstance == _facade)
            {
                _container.FacadeInstance = null;
            }
        }
    }
}