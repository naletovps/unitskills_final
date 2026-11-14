namespace UnitSkills.Features.SceneLoading
{
    using UnitSkills.Features.DataManagment;

    /// <summary>
    ///  нопка загрузки сцены без сохранени€
    /// </summary>
    public class LoadUnsavedButtonView : LoadSceneButtonView
    {
        protected override void OnButtonClicked()
        {
            DataManager.Instance.LoadSavedData = false;

            base.OnButtonClicked();
        }
    }
}