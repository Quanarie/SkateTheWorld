using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject skater;
    [SerializeField] GameObject[] enemies;

    [SerializeField] private float minTimeBetweenSpawn;
    [SerializeField] private float maxTimeBetweenSpawn;
    [SerializeField] private float increaseHealth;
    [SerializeField] private float increaseDamage;

    private float timeFromStart = 0;
    private float timeFromPreviousSpawn = 0;
    private float complexity = 0.1f;
    private float timeBetweenSpawn = 0;

    private void Update()
    {
        timeFromStart += Time.deltaTime;
        if (timeFromStart > 10)
        {
            complexity = 0.4f;
        }
        if (timeFromStart > 20)
        {
            complexity = 1f;
        }
        if (timeFromPreviousSpawn > timeBetweenSpawn)
        {
            GameObject enemy = Instantiate(enemies[Random.Range(0, (int)(enemies.Length * complexity))], transform.position, transform.rotation);
            enemy.GetComponent<EnemyAttack>().SetSkater(skater);
            enemy.GetComponent<EnemyHealth>().SetSkater(skater);
            enemy.GetComponent<EnemyMovement>().SetSkater(skater.transform);
            timeFromPreviousSpawn = 0;
            timeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        }
        else
        {
            timeFromPreviousSpawn += Time.deltaTime;
        }
    }
}
