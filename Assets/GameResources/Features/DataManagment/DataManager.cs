namespace UnitSkills.Features.DataManagment
{
    using UnitSkills.Features.Utils;
    using UnityEngine;

    /// <summary>
    /// Репозиторий сохраняемых данных
    /// </summary>
    public sealed class DataManager : SingletonMonoBehaviour<DataManager>
    {
        private const string SaveKey = "GameSaveExists";

        /// <summary>
        /// Нужно ли загружать сохраненные данные
        /// </summary>
        public bool LoadSavedData { get; set; } = false;

        /// <summary>
        /// Существует ли сохранение игры
        /// </summary>
        public bool HasSave => PlayerPrefs.HasKey(SaveKey);

        /// <summary>
        /// Получить данные
        /// </summary>
        public T GetData<T>(string key, T defaultData) where T : IData
        {
            if (!LoadSavedData || !PlayerPrefs.HasKey(key))
            {
                return defaultData;
            }

            string json = PlayerPrefs.GetString(key);

            if (string.IsNullOrEmpty(json))
            {
                return defaultData;
            }

            return JsonUtility.FromJson<T>(json);
        }

        /// <summary>
        /// Сохранить данные
        /// </summary>
        public void SetData<T>(string key, T data)
        {
            string json = JsonUtility.ToJson(data);

            PlayerPrefs.SetString(key, json);
            PlayerPrefs.SetInt(SaveKey, 1);
            PlayerPrefs.Save();
        }
    }
}