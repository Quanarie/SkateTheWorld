using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float distance;
    [SerializeField] private int damage;
    [SerializeField] private Transform skater;

    private float startTime = 0;
    private Vector2 startDirection;
    private void Start()
    {
        if (skater.lossyScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            startDirection = Vector2.left;
        }
        else startDirection = Vector2.right;
    }
    private void Update()
    {
        if (skater.lossyScale.x < 0)
        {
            transform.Translate(startDirection * speed * Time.deltaTime);
        }
        else
            transform.Translate(startDirection * speed * Time.deltaTime);
        startTime += Time.deltaTime;
        if (startTime > lifeTime) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D  collider)
    {
        if (collider.TryGetComponent(out EnemyHealth _))
        {
            collider.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    public void SetSkater(Transform sk)
    {
        skater = sk;
    }
}
