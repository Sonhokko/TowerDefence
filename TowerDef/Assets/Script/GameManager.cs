using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private int levelToUnlock;
    [SerializeField] private SceneFader fader;


    public static bool GameIsOver;

    private void Start()
    {
        GameIsOver = false;
    }

    private void Update()
    {
        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
            EndGame();
    }

    public void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        Debug.Log("LVL WON");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        fader.FadeTo(3);
    }
}
