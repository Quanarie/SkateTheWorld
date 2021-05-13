using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkaterHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject damageTakenEffect;
    [SerializeField] private GameObject healEffect;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite halfFullHeart;
    [SerializeField] private Sprite emptyHeart;

    private int maxHealth;

    private void Start()
    {
        maxHealth = health;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if ((i + 1) * 2 <= health)
            {
                hearts[i].sprite = fullHeart;
            }
            else if ((i + 1) * 2 == health + 1)
            {
                hearts[i].sprite = halfFullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
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
