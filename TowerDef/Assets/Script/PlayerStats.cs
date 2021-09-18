using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   [SerializeField] private int startMoney = 400;
   [SerializeField] private int startLives = 20;
   public static int Money;
   public static int Lives;
   public static int Rounds;

   private void Start()
   {
       Lives = startLives;
       Money = startMoney;
       Rounds = 0;
   }
}
