using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathEffectPref;
    [SerializeField] private Image healthBar;
    private int worth = 50;
    private float health;

    public float startSpeed = 10f;
    public float startHealth = 100f;

    [HideInInspector]
    public float speed;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }


    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float percent)
    {
        speed = startSpeed * (1f - percent);
    }

    public void Die()
    {
        PlayerStats.Money += worth;

        GameObject deathEffect = Instantiate(deathEffectPref, transform.position, Quaternion.identity);
        Destroy(deathEffect, 2f);
        WaveSpawner.EnemiesAlive--;

        Destroy(this.gameObject);
    }


}
