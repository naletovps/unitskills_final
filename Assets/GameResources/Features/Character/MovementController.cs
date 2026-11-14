namespace UnitSkills.Features.Character
{
    using System;
    using Unitskills.Features.Facade;
    using UnitSkills.Features.Input;
    using UnityEngine;
    using UnityEngine.InputSystem;

    /// <summary>
    /// Контроллер отвечающий за перемещение игрока
    /// </summary>
    public sealed class MovementController : FacadeModule
    {
        public Vector3 CurrentVelocity => _velocity;

        [SerializeField] private float _speed = 5f;

        private Rigidbody _rigidbody = default;
        private InputAction _moveAction = default;

        private Vector2 _inputVector = Vector2.zero;
        private Vector3 _velocity = Vector3.zero;

        public override void OnModuleInited()
        {
            _rigidbody = Facade.GetFacadeModule<CharacterComponents>().GetComponent<Rigidbody>();
            _moveAction = Facade.GetFacadeModule<PlayerInputModule>().PlayerInput.Gameplay.Move;

            _moveAction.performed += OnMovePerformed;
            _moveAction.canceled += OnMoveStopped;
        }

        public override void OnModuleDisposed()
        {
            _moveAction.canceled -= OnMoveStopped;
            _moveAction.performed -= OnMovePerformed;
        }

        private void OnMovePerformed(InputAction.CallbackContext context) => _inputVector = context.ReadValue<Vector2>();
        private void OnMoveStopped(InputAction.CallbackContext context) => _inputVector = Vector2.zero;

        private void FixedUpdate()
        {
            _velocity = new Vector3(_inputVector.x, 0f, _inputVector.y) * _speed;
            _rigidbody.linearVelocity = _velocity;
        }
    }
}