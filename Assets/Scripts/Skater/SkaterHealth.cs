using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkaterHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject damageTakenEffect;
    [SerializeField] private GameObject healEffect;

    private int maxHealth;

    private void Start()
    {
        maxHealth = health;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            Instantiate(damageTakenEffect, transform);
            health -= damage;
        }
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Heal(int value)
    {
        if (value > 0)
        {
            Instantiate(healEffect, transform);
            health = Mathf.Min(maxHealth, health + value);
        }
    }
}
