namespace UnitSkills.Features.Character
{
    using UnitSkills.Features.Facade;
    using UnitSkills.Features.Physics;
    using UnityEngine;

    /// <summary>
    /// Визуальное представление врага
    /// </summary>
    public class EnemyAnimationView : MonoBehaviour
    {
        protected readonly int RunHash = Animator.StringToHash("Velocity");

        [SerializeField] protected Animator animator;

        protected AbstractMovementController movementController;

        protected void Start()
        {
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }

            movementController = GetComponentInParent<AbstractFacade>().GetFacadeModule<AbstractMovementController>();
        }

        protected virtual void Update() => animator.SetFloat(RunHash, movementController.CurrentVelocity.magnitude > 0.01f ? 1f : 0f);
    }
}