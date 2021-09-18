using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private SceneFader fader;
    [SerializeField] private Button[] lvlButtons;

    private void Start()
    {
        int lvlReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > lvlReached)
            lvlButtons[i].interactable = false;
        }
    }

    public void Select (int levelIndex)
    {
        fader.FadeTo(levelIndex);
    }
}
