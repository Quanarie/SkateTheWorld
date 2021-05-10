using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkaterHealth : MonoBehaviour
{
    [SerializeField] private int health;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            health -= damage;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
