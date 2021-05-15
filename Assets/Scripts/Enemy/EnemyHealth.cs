using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject skater;
    [SerializeField] private int health;
    [SerializeField] private GameObject deathSound;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            health -= damage;
        }
        if (health <= 0)
        {
            skater.GetComponent<SkaterScore>().AddScore(1);
            Instantiate(deathSound, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void SetSkater(GameObject skateBoarder)
    {
        skater = skateBoarder;
    }

    /*public int Health
    {
        get { return health; }
        set { health = value; }
    }*/
}
