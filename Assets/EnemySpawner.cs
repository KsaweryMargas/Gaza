using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    List<Vector3> spawnPoints;
    public GameObject enemy;
    void Start()
    {
        Transform sp = transform.Find("SpawnPositions");
        spawnPoints = new List<Vector3>();
        foreach (Transform child in sp)
        {
            spawnPoints.Add(child.position);
        }
        InvokeRepeating("Spawn", 0, 0.1f);
    }
    void Spawn()
    {
        int index = Random.Range(0, spawnPoints.Count);
        Instantiate(enemy, spawnPoints[index], Quaternion.identity);
    }
}
