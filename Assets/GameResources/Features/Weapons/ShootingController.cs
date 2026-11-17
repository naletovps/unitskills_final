namespace UnitSkills.Features.Shooting
{
    using System;
    using UnitSkills.Features.Facade;
    using UnitSkills.Features.Input;
    using UnityEngine;
    using UnityEngine.InputSystem;

    /// <summary>
    /// Контроллер стрельбы персонажа
    /// </summary>
    public class ShootingController : FacadeModule
    {
        public event Action onShotPerformed = delegate { };

        [SerializeField, Min(0f)] protected float cooldown = 0.4f;

        protected InputAction shootAction = default;
        protected AmmoModel modelAmmo = default;
        protected float nextShotTime = 0f;
        protected bool isShooting = false;

        public override void OnModuleInited()
        {
            modelAmmo = Facade.GetDataFacadeModule<AmmoModel>();
            shootAction = Facade.GetFacadeModule<PlayerInputModule>().PlayerInput.Gameplay.Shoot;

            shootAction.performed += OnShootPerformed;
            shootAction.canceled += OnShootCanceled;
        }

        public override void OnModuleDisposed()
        {
            shootAction.performed -= OnShootPerformed;
            shootAction.canceled -= OnShootCanceled;
        }

        protected virtual void Update()
        {
            if (isShooting)
            {
                TryShoot();
            }
        }

        /// <summary>
        /// Нажатие кнопки стрельбы
        /// </summary>
        protected virtual void OnShootPerformed(InputAction.CallbackContext context)
        {
            isShooting = true;
            TryShoot();
        }

        /// <summary>
        /// Отпускание кнопки стрельбы
        /// </summary>
        protected virtual void OnShootCanceled(InputAction.CallbackContext context) => isShooting = false;

        /// <summary>
        /// Попытаться выстрелить
        /// </summary>
        protected virtual bool TryShoot()
        {
            if (Time.time < nextShotTime || modelAmmo.AmmoCount <= 0)
            {
                return false;
            }

            modelAmmo.AmmoCount--;
            nextShotTime = Time.time + cooldown;

            onShotPerformed.Invoke();

            return true;
        }
    }
}
