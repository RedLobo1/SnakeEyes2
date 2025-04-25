using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;

    public void SpawSnakes()
    {
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}