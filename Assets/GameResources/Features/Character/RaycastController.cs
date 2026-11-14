namespace UnitSkills.Features.Character
{
    using UnitSkills.Features.Facade;
    using UnitSkills.Features.Input;
    using UnityEngine;
    using UnityEngine.InputSystem;

    /// <summary>
    /// Контроллер луча персонажа.
    /// Строит луч из камеры через курсор или палец, рисует его
    /// и отдаёт компонент заданного типа с объекта, в который луч попал.
    /// </summary>
    public class RaycastController : FacadeModule
    {
        [SerializeField] protected Camera cameraView = default;
        [SerializeField, Min(0f)] protected float rayDistance = 100f;

        protected InputAction _lookAction = default;

        /// <summary>
        /// Вызывается при инициализации модуля
        /// </summary>
        public override void OnModuleInited()
        {
            if (cameraView == null)
            {
                cameraView = Camera.main;
            }

            _lookAction = Facade.GetFacadeModule<PlayerInputModule>().PlayerInput.Gameplay.Look;
        }

#if UNITY_EDITOR
        protected virtual void Update() => DrawRay();
#endif

        public virtual bool TryGetRay(out Ray ray)
        {
            ray = default;

            if (cameraView == null || Mouse.current == null)
            {
                return false;
            }

            Vector2 mousePosition = Mouse.current.position.ReadValue();
            ray = cameraView.ScreenPointToRay(mousePosition);

            return true;
        }

        public virtual bool TryHit(out RaycastHit hit)
        {
            hit = default;

            if (!TryGetRay(out Ray ray))
            {
                return false;
            }

            return Physics.Raycast(ray, out hit, rayDistance);
        }

        public virtual bool TryHit<T>(out T target) where T : Component
        {
            target = default;

            if (!TryHit(out RaycastHit hit))
            {
                return false;
            }

            return hit.collider.TryGetComponent(out target);
        }

        public virtual bool TryGetPointOnPlane(float height, out Vector3 point)
        {
            point = default;

            if (!TryGetRay(out Ray ray))
            {
                return false;
            }

            Plane plane = new Plane(Vector3.up, new Vector3(0f, height, 0f));

            if (!plane.Raycast(ray, out float distance))
            {
                return false;
            }

            if (distance > rayDistance)
            {
                return false;
            }

            point = ray.GetPoint(distance);

            return true;
        }

        protected virtual void DrawRay()
        {
            if (TryGetRay(out Ray ray))
            {
                Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.white);
            }
        }
    }

}