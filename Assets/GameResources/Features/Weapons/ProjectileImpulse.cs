namespace UnitSkills.Features.Physics
{
    using UnityEngine;

    /// <summary>
    /// Класс выпускаемого физического снаряда
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class ProjectileImpulse : MonoBehaviour
    {
        [SerializeField] protected Rigidbody rigidbody;
        [SerializeField] protected float force = 10f;

        private void Awake()
        {
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody>();
            }
        }

        public void Apply(Vector3 direction)
        {
            rigidbody.linearVelocity = direction.normalized * force;
            rigidbody.angularVelocity = Vector3.zero;
        }

        protected virtual void OnDisable()
        {
            rigidbody.linearVelocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
    }
}