namespace UnitSkills.Features.SceneLoading
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Отображает бар загрузки сцены
    /// </summary>
    [RequireComponent(typeof(Image))]
    public sealed class LoadingBarView : AbstractLoadView
    {
        [SerializeField] private Image _loadingBar = default;

        private void Awake()
        {
            if (_loadingBar == null)
            {
                _loadingBar = GetComponent<Image>();
            }
        }

        protected override void OnUpdateProgressValue(float value)
        {
            _loadingBar.fillAmount = value;
        }
    }
}