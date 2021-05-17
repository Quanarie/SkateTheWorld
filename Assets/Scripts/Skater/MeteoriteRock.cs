using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteRock : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private int damage;

    private float startTime = 0;

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        startTime += Time.deltaTime;
        if (startTime > lifeTime) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out EnemyHealth _))
        {
            collider.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        else if (!collider.TryGetComponent(out MeteoriteRock _))
            Destroy(gameObject);
    }
}
