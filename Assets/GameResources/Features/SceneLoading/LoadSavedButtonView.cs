namespace UnitSkills.Features.SceneLoading
{
    using UnitSkills.Features.DataManagment;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Кнопка загрузки сцены с сохранением
    /// </summary>
    public class LoadSavedButtonView : LoadSceneButtonView
    {
        [SerializeField] protected Text text = default;
        [SerializeField] protected Color inactiveColor = Color.grey;

        private void Start()
        {
            if (text == null)
            {
                text = GetComponentInChildren<Text>();
            }

            button.interactable = DataManager.Instance.HasSave;
            text.color = inactiveColor;
        }

        protected override void OnButtonClicked()
        {
            DataManager.Instance.LoadSavedData = true;

            base.OnButtonClicked();
        }
    }
}