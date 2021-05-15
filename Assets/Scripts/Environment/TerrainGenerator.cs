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
    private List<GameObject> cells;
    private List<GameObject> BGs;

    private void Start()
    {
        cells = new List<GameObject>();
        BGs = new List<GameObject>();
        previousPositionY = transform.position.y;
    }

    private void Update()
    {
        Generate();
        Delete();
    }

    private void Generate()
    {
        if (skater.position.x + 20 > previousPositionX)
        {
            float yOffSet = Random.Range(-1, 2);
            if (previousPositionY + yOffSet < Height + transform.position.y && previousPositionY + yOffSet > transform.position.y && previousPositionX % 3 == 0)
                previousPositionY += yOffSet;
            var cellClone = Instantiate(cell, new Vector3(previousPositionX, previousPositionY, 0), transform.rotation, transform);
            cells.Add(cellClone);
            previousPositionX++;
        }
        if (skater.position.x + 12.6f >= previousBGPosX)
        {
            previousBGPosX += 12.6f;
            var BGClone = Instantiate(background, new Vector3(previousBGPosX, 0, 0), transform.rotation, transform);
            BGs.Add(BGClone);
        }
    }

    private void Delete()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].transform.position.x < Camera.main.transform.position.x - 1600 * Camera.main.orthographicSize / 900 - 1)
            {
                Destroy(cells[i]);
                cells.RemoveAt(i);
            }
        }
        for (int i = 0; i < BGs.Count; i++)
        {
            if (BGs[i].transform.position.x < Camera.main.transform.position.x - 1600 * Camera.main.orthographicSize / 900 - 7)
            {
                Destroy(BGs[i]);
                BGs.RemoveAt(i);
            }
        }
    }
}
