namespace UnitSkills.Features.Character
{
    using UnitSkills.Features.Installer;
    using UnityEngine;

    /// <summary>
    /// Визуальное представление персонажа
    /// </summary>
    public class AnimationView : CharacterProvider
    {
        protected readonly int RunHash = Animator.StringToHash("Velocity");

        [SerializeField] protected Animator animator;

        protected CharacterMovementController movementController; 

        protected override void OnFacadeInited()
        {
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }
            
            movementController = container.CharacterInstance.GetFacadeModule<CharacterMovementController>();
        }

        protected virtual void Update() => animator.SetFloat(RunHash, movementController.CurrentVelocity.magnitude > 0.01f ? 1f : 0f);
    }
}