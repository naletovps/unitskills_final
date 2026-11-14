#if UNITY_EDITOR
namespace UnitSkills.Editor
{
    using UnityEditor;
    using UnityEditor.SceneManagement;
    using UnityEngine.SceneManagement;

    /// <summary>
    /// Устанавливает начальную сцену при запуске Play Mode
    /// </summary>
    [InitializeOnLoad]
    public static class EntryPointLoader
    {
        static EntryPointLoader()
        {
            EditorApplication.playModeStateChanged += LoadDefaultScene;
        }

        static void LoadDefaultScene(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            }

            if (state == PlayModeStateChange.EnteredPlayMode)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
#endif