namespace UnitSkills.Features.Utilities
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Хранит информацию о самом высоком значении
    /// </summary>
    public sealed class Scoreboard : MonoBehaviour
    {
        public event Action onHighestScoreChanged = delegate { };

        [SerializeField] private Scorer _scorer;

        private int _highestScore = 0;

        private void Awake()
        {
            _scorer.onGameFinished += OnGameFinished;
        }

        private void OnDestroy()
        {
            _scorer.onGameFinished -= OnGameFinished;
        }

        private void OnGameFinished()
        {
            int currentScore = _scorer.CurrentScore;

            if (currentScore > _highestScore)
            {
                _highestScore = currentScore;

                onHighestScoreChanged.Invoke();

                Debug.Log($"Highest score has been changed: {_highestScore}");
            }
        }
    }
}