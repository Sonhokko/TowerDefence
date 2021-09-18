using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private Text moneyText;

    private void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }

}
