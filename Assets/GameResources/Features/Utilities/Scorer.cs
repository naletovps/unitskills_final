namespace UnitSkills.Features.Utilities
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Мок-объект имитирующий геймплей
    /// </summary>
    public sealed class Scorer : MonoBehaviour
    {
        public event Action onGameFinished = delegate { };
        public event Action onCurrentScoreChanged = delegate { };

        public int CurrentScore => _currentScore;

        private int _currentScore = 0;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                _currentScore++;
                Debug.Log($"Current score: {_currentScore}");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                FinishGame();
                Debug.Log($"Game is finished!");
            }
        }

        private void FinishGame()
        {
            onGameFinished.Invoke();
            
            _currentScore = 0;
        }
    }
}