namespace UnitSkills.Features.Utils
{
    /// <summary>
    /// Выходит из игры
    /// </summary>
    public class ExitButton : AbstractButton
    {
        protected override void OnButtonClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}