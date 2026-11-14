namespace UnitSkills.Features.Character
{
    using UnitSkills.Features.Facade;
    using UnityEngine;

    /// <summary>
    /// Поворачивает персонажа в сторону курсора
    /// </summary>
    public sealed class CharacterRotationController : FacadeModule
    {
        private Rigidbody _rigidbody = default;
        private RaycastController _raycast = default;

        private Quaternion _targetRotation = Quaternion.identity;

        public override void OnModuleInited()
        {
            _rigidbody = Facade.GetFacadeModule<CharacterComponents>().GetComponent<Rigidbody>();
            _raycast = Facade.GetFacadeModule<RaycastController>();
        }

        private void Update()
        {
            if (!_raycast.TryGetPointOnPlane(_rigidbody.position.y, out Vector3 point))
            {
                return;
            }

            Vector3 direction = point - _rigidbody.position;
            direction.y = 0f;

            if (direction.sqrMagnitude < 0.001f)
            {
                return;
            }

            _targetRotation = Quaternion.LookRotation(direction);
        }

        private void FixedUpdate()
        {
            if (Quaternion.Angle(_rigidbody.rotation, _targetRotation) > 0.5f)
            {
                _rigidbody.MoveRotation(_targetRotation);
            }
        }
    }
}