namespace UnitSkills.Features.Installer
{
    using UnitSkills.Features.Character;
    using UnityEngine;

    /// <summary>
    /// Регистрирует персонажа в контейнере
    /// </summary>
    public sealed class CharacterInstaller : MonoBehaviour
    {
        [SerializeField] private CharacterFacade _characterFacade = default;
        [SerializeField] private CharacterContainer _container = default;

        private void Awake() => _container.CharacterInstance = _characterFacade;
        private void OnDestroy() => _container.CharacterInstance = null;
    }
}