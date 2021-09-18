using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
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
}
