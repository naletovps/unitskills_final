namespace UnitSkills.Features.Character
{
    using UnitSkills.Features.Installer;
    using UnitSkills.Features.Physics;
    using UnityEngine;

    /// <summary>
    /// Визуальное представление персонажа
    /// </summary>
    public class AnimationView : FacadeProvider
    {
        protected readonly int RunHash = Animator.StringToHash("Velocity");

        [SerializeField] protected Animator animator;

        protected AbstractMovementController movementController; 

        protected override void OnFacadeInited()
        {
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }

            movementController = container.FacadeInstance.GetFacadeModule<AbstractMovementController>();
        }

        protected virtual void Update() => animator.SetFloat(RunHash, movementController.CurrentVelocity.magnitude > 0.01f ? 1f : 0f);
    }
}