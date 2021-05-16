using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject skater;
    [SerializeField] GameObject[] enemies;

    [SerializeField] private float minTimeBetweenSpawn;
    [SerializeField] private float maxTimeBetweenSpawn;

    private float increaseForHealth = 0;
    private float timeFromStart = 0;
    private float timeFromPreviousSpawn = 0;
    private float complexity = 0.1f;
    private float timeBetweenSpawn = 0;

    private void Update()
    {
        timeFromStart += Time.deltaTime;
        if (complexity! <= 1) complexity += Time.deltaTime * 0.01f;
        if (minTimeBetweenSpawn >= 2) minTimeBetweenSpawn -= Time.deltaTime * 0.01f;
        if (maxTimeBetweenSpawn >= 5) maxTimeBetweenSpawn -= Time.deltaTime * 0.01f;
        increaseForHealth += Time.deltaTime * 0.01f;

        if (timeFromPreviousSpawn > timeBetweenSpawn)
        {
            GameObject enemy = Instantiate(enemies[Random.Range(0, (int)(enemies.Length * complexity))], transform.position, transform.rotation);
            enemy.GetComponent<EnemyAttack>().SetSkater(skater);
            enemy.GetComponent<EnemyHealth>().SetSkater(skater);
            enemy.GetComponent<EnemyMovement>().SetSkater(skater.transform);

            enemy.GetComponent<EnemyHealth>().Health = enemy.GetComponent<EnemyHealth>().Health + (int)increaseForHealth;

            timeFromPreviousSpawn = 0;
            timeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        }
        else
        {
            timeFromPreviousSpawn += Time.deltaTime;
        }
    }
}
