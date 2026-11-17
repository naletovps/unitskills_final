namespace UnitSkills.Features.Gameplay
{
    using UnitSkills.Features.Installer;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Отображение счета
    /// </summary>
    public class ScoreView : FacadeProvider
    {
        [SerializeField] protected Text scoreText;
        protected ScoreModel scoreModel;

        protected override void OnFacadeInited()
        {
            if (scoreText == null)
            {
                scoreText = GetComponent<Text>();
            }

            scoreModel = container.FacadeInstance.GetDataFacadeModule<ScoreModel>();
            scoreModel.onScoreChanged += OnScoreChanged;
            OnScoreChanged();
        }

        private void OnScoreChanged() => scoreText.text = scoreModel.Score.ToString();
    }
}