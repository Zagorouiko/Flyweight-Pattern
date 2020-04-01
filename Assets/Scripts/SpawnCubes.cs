using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject cube;
    public int rows;
    public int columns;

    void Start()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int z = 0; z < columns; z++)
            {
                GameObject instance = Instantiate(cube);
                Vector3 position = new Vector3(x, 
                    Mathf.PerlinNoise(x * 0.21f, z * 0.21f), 
                    z);

                instance.transform.position = position;
            }
        }  
    }

 
}
