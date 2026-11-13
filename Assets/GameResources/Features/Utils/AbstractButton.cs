namespace UnitSkills.Features.Utils
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Абстрактный класс для кнопки
    /// </summary>
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButton : MonoBehaviour
    {
        [SerializeField] protected Button button = default;

        private void Awake()
        {
            if (button == null)
            {
                button = GetComponent<Button>();
            }

            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnButtonClicked);
        }

        protected abstract void OnButtonClicked();
    }
}