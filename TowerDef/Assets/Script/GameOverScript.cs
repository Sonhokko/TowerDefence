using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private Text roundsText;
    [SerializeField] private SceneFader sceneFader;

    private void OnEnable() => roundsText.text = PlayerStats.Rounds.ToString();

    public void Retry() => sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex);


    public void Menu() => sceneFader.FadeTo(0);

}
