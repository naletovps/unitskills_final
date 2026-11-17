namespace UnitSkills.Features.Weapons
{
    using UnitSkills.Features.Installer;
    using UnitSkills.Features.Shooting;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Отображение количество снарядов
    /// </summary>
    public class AmmoView : CharacterProvider
    {
        [SerializeField] protected Text ammoText;
        protected AmmoModel ammoModel;

        protected override void OnFacadeInited()
        {
            if (ammoText == null)
            {
                ammoText = GetComponent<Text>();
            }

            ammoModel = container.CharacterInstance.GetDataFacadeModule<AmmoModel>();
            ammoModel.onAmmoCountChanged += OnScoreChanged;
            OnScoreChanged();
        }

        private void OnScoreChanged() => ammoText.text = $"{ammoModel.AmmoCount}/{ammoModel.Capacity}";
    }
}