using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private Text livesText;

    private void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " LIVES";
    }
}
