using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SkaterHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject damageTakenEffect;
    [SerializeField] private GameObject healEffect;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite halfFullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private TextMeshProUGUI gameOver;

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
            gameOver.text = "YOU DIED";
            GetComponent<OnSkateMovement>().enabled = false;
            GetComponent<RegularMovement>().enabled = false;
            GetComponent<TransportTypeController>().enabled = false;
            StartCoroutine(StartScene());
        }
    }

     IEnumerator StartScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }

    public void Heal(int value)
    {
        if (value > 0)
        {
            health = Mathf.Min(maxHealth, health + value);
        }
    }
}
