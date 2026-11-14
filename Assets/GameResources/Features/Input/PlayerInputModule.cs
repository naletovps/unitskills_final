namespace UnitSkills.Features.Input
{
    using Unitskills.Features.Facade;

    /// <summary>
    /// Управляет системой ввода
    /// </summary>
    public sealed class InputSystemModule : ModuleFacade
    {
        /// <summary>
        /// Текущая система ввода
        /// </summary>
        public PlayerInputActions PlayerInput { get; private set; }

        public override void OnModuleInited()
        {
            PlayerInput = new PlayerInputActions();
            PlayerInput.Enable();
        }

        public override void OnModuleDisposed()
        {
            PlayerInput.Disable();
        }
    }
}