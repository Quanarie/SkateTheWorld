using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cell;
    [SerializeField] private Transform startPos;
    [SerializeField] private int Height, Width;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        int y = 0;
        for (int x = 0; x < Width; x++)
        {
            var cellClone = Instantiate(cell, startPos);
            if (x % 4 == 0) y += Random.Range(-1, 2);
            cellClone.transform.localPosition = new Vector3(x, y, 0);
        }
    }
}
