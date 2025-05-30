using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuSceneManager : MonoBehaviour
{
    public void OnGameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
