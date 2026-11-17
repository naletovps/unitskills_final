namespace UnitSkills.Features.Gameplay
{
    using System;
    using UnitSkills.Features.DataManagment;
    using UnitSkills.Features.Facade;
    using UnityEngine;

    /// <summary>
    /// Очки текущей сессии и постоянный рекорд
    /// </summary>
    [CreateAssetMenu(fileName = "New Score Model", menuName = "UnitSkills/Data/Score")]
    public class ScoreModel : DataFacadeModule
    {
        /// <summary>
        /// Данные очков для сохранения
        /// </summary>
        [Serializable]
        public class ScoreSaveData : IData
        {
            public int score;
            public int bestScore;
        }

        /// <summary>
        /// Вызывается при изменении очков
        /// </summary>
        public event Action onScoreChanged = delegate { };
        
        /// <summary>
        /// Счетчик очков
        /// </summary>
        public int Score 
        {
            get => score;
            private set
            {
                if (score == value)
                {
                    return;
                }

                score = value;
                onScoreChanged.Invoke();
            }
        }
        public int BestScore { get; private set; }

        protected int score = default;

        private const string SaveKey = "ScoreModel";

        public override void OnModuleInited()
        {
            // на завершении сессии вызвать SetBestScore();

            if (DataManager.Instance == null)
            {
                return;
            }

            ScoreSaveData data = DataManager.Instance.GetData(SaveKey,
                new ScoreSaveData
                {
                    score = 0,
                    bestScore = 0,
                });

            Score = data.score;
            BestScore = data.bestScore;
        }

        public override void OnModuleDisposed()
        {
            if (DataManager.Instance == null)
            {
                return;
            }

            ScoreSaveData data = new ScoreSaveData
            {
                score = Score,
                bestScore = BestScore,
            };

            DataManager.Instance.SetData(SaveKey, data);
        }

        /// <summary>
        /// Обнуление счета
        /// </summary>
        public void ResetRun() => Score = 0;

        /// <summary>
        /// Добавляет очки
        /// </summary>
        public void Add(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            Score += amount;
        }

        private void SetBestScore()
        {
            if (Score <= BestScore)
            {
                return;
            }

            BestScore = Score;
        }
    }
}
