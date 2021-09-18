using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(1);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
