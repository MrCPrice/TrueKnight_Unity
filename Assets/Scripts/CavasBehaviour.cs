using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class CavasBehaviour : MonoBehaviour
{
    public void LoadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void OptionsGame()
    {
        Debug.Log("Options was clicked");
    }

    public void QuitGame()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();
    }
}
