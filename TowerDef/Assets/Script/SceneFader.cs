using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private AnimationCurve animationCurve;

    private void Start()
    {
        StartCoroutine(Fade());
    }

    public void FadeTo(int sceneIndex)
    {
        StartCoroutine(FadeOut(sceneIndex));
    }

    private IEnumerator Fade()
    {
        float timeValue = 1f;

        while (timeValue > 0f)
        {
            timeValue -= Time.deltaTime;
            float alphaValue = animationCurve.Evaluate(timeValue);
            fadeImage.color = new Color(0f, 0f, 0f, alphaValue);
            yield return 0;
        }
    }

    private IEnumerator FadeOut(int sceneIndex)
    {
        float timeValue = 0f;

        while (timeValue < 1f)
        {
            timeValue += Time.deltaTime;
            float alphaValue = animationCurve.Evaluate(timeValue);
            fadeImage.color = new Color(0f, 0f, 0f, alphaValue);
            yield return 0;
        }

        SceneManager.LoadScene(sceneIndex);
    }

}
