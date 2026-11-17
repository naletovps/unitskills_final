namespace UnitSkills.Features.Physics
{
    using UnityEngine;

    /// <summary>
    /// Ищет компонент на коллайдере или в его родителях
    /// </summary>
    public abstract class AbstractGenericTrigger<T> : MonoBehaviour
    {
        protected virtual void OnTriggerEnter(Collider other)
        {
            T target = other.GetComponentInParent<T>();

            if (target != null)
            {
                OnTriggerEnterSuccessfully(target);
            }
            else
            {
                OnTriggerEnterFail();
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            T target = other.GetComponentInParent<T>();

            if (target != null)
            {
                OnTriggerExitSuccessfully(target);
            }
        }

        protected virtual void OnTriggerEnterSuccessfully(T target) { }
        protected virtual void OnTriggerEnterFail() { }
        protected virtual void OnTriggerExitSuccessfully(T target) { }
    }
}
