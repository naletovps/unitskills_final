namespace UnitSkills.Features.SceneLoading
{
    using UnitSkills.Features.Utils;
    using UnityEngine;

    /// <summary>
    /// Кнопка зугрузки целевой сцены
    /// </summary>
    public class LoadButtonView : AbstractButton
    {
        [SerializeField] protected string targetScene = default;

        protected bool isAlreadyClicked = false;

        protected override void OnButtonClicked()
        {
            if (isAlreadyClicked)
            {
                return;
            }

            isAlreadyClicked = true;

            SceneLoadingController.StartLoading(targetScene);
        }
    }
}