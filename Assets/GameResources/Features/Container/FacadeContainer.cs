namespace UnitSkills.Features.Installer
{
    using System;
    using UnitSkills.Features.Facade;
    using UnityEngine;

    /// <summary>
    /// Хранит ссылку персонажа
    /// </summary>
    [CreateAssetMenu(fileName = "New Character Container", menuName = "UnitSkills/Data/CharacterContainer")]
    public sealed class FacadeContainer : ScriptableObject
    {
        /// <summary>
        /// Вызывается при инициализации персонажа
        /// </summary>
        public event Action onCharacterInited = delegate { };

        /// <summary>
        /// Вызывается при удалении персонажа
        /// </summary>
        public event Action onCharacterDisposed = delegate { };

        /// <summary>
        /// Текущий экземпляр персонажа
        /// </summary>
        public AbstractFacade FacadeInstance
        {
            get => _characterInstance;
            set
            {
                if (value != null && value != _characterInstance)
                {
                    _characterInstance = value;
                    onCharacterInited.Invoke();

                    return;
                }
                if (value == null)
                {
                    _characterInstance = null;
                    onCharacterDisposed.Invoke();
                }
            }
        }

        [SerializeField] private AbstractFacade _characterInstance = default;
    }
}