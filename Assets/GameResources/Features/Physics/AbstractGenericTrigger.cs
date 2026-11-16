namespace UnitSkills.Features.Physics
{
    using UnityEngine;

    /// <summary>
    /// Триггер, который ищет на вошедшем объекте компонент заданного типа.
    /// </summary>
    /// <typeparam name="T">Компонент, который нужно получить из коллайдера.</typeparam>
    public abstract class AbstractGenericTrigger<T> : MonoBehaviour where T : Component
    {
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out T targetComponent))
            {
                OnTriggerEnterSuccessfully(targetComponent);
                return;
            }

            OnTriggerEnterFail();
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out T targetComponent))
            {
                OnTriggerExitSuccessfully(targetComponent);
                return;
            }

            OnTriggerExitFail();
        }

        /// <summary>
        /// Компонент на вошедшем объекте найден.
        /// </summary>
        /// <param name="targetComponent">Найденный компонент.</param>
        protected virtual void OnTriggerEnterSuccessfully(T targetComponent)
        {
        }

        /// <summary>
        /// На вошедшем объекте нужного компонента нет.
        /// </summary>
        protected virtual void OnTriggerEnterFail()
        {
        }

        /// <summary>
        /// Компонент на вышедшем объекте найден.
        /// </summary>
        /// <param name="targetComponent">Найденный компонент.</param>
        protected virtual void OnTriggerExitSuccessfully(T targetComponent)
        {
        }

        /// <summary>
        /// На вышедшем объекте нужного компонента нет.
        /// </summary>
        protected virtual void OnTriggerExitFail()
        {
        }
    }
}
