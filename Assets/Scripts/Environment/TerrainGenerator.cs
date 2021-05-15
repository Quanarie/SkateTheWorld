using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private Transform skater;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject cell;
    [SerializeField] private int Height;

    private float previousPositionX = 0;
    private float previousPositionY = 0;
    private float previousBGPosX = 0;

    private void Start()
    {
        previousPositionY = transform.position.y;
    }

    private void Update()
    {
        Generate();
    }

    private void Generate()
    {
        if (skater.position.x + 20 > previousPositionX)
        {
            float yOffSet = Random.Range(-1, 2);
            if (previousPositionY + yOffSet < Height + transform.position.y && previousPositionY + yOffSet > transform.position.y && previousPositionX % 3 == 0)
                previousPositionY += yOffSet;
            var cellClone = Instantiate(cell, new Vector3(previousPositionX, previousPositionY, 0), transform.rotation, transform);
            previousPositionX++;
        }
        if (skater.position.x + 12.6f >= previousBGPosX)
        {
            previousBGPosX += 12.6f;
            Instantiate(background, new Vector3(previousBGPosX, 0, 0), transform.rotation, transform);
        }
    }
}
