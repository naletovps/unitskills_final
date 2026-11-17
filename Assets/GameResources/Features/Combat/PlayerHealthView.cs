namespace UnitSkills.Features.Combat
{
    using UnitSkills.Features.Installer;
    using UnityEngine;
    using UnityEngine.UI;

    public class PlayerHealthView : FacadeProvider
    {
        [SerializeField] protected Image fillImage = default;
        protected HealthModel healthModel;

        protected override void OnFacadeInited()
        {
            healthModel = container.FacadeInstance.GetDataFacadeModule<HealthModel>();
            healthModel.onHealthChanged += OnHealthChanged;
            OnHealthChanged();
        }

        private void OnHealthChanged() => fillImage.fillAmount = (float)healthModel.Current / healthModel.Max;
    }
}