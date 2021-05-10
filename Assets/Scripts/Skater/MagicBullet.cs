using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float distance;
    [SerializeField] private int damage;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D  collider)
    {
        if (collider.TryGetComponent(out EnemyHealth _))
        {
            collider.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
