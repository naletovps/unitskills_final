namespace UnitSkills.Features.Combat
{
    using UnitSkills.Features.Installer;
    using UnityEngine;
    using UnityEngine.UI;

    public class PlayerHealthView : CharacterProvider
    {
        [SerializeField] protected Image fillImage = default;
        protected HealthModel healthModel;

        protected override void OnFacadeInited()
        {
            healthModel = container.CharacterInstance.GetDataFacadeModule<HealthModel>();
            healthModel.onHealthChanged += OnHealthChanged;
            OnHealthChanged();
        }

        private void OnHealthChanged() => fillImage.fillAmount = healthModel.Current / healthModel.Max;
    }
}