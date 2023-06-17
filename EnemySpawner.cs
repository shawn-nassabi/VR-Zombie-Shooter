using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private GameObject zombie;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnZombie();
        }
    }
    private void SpawnZombie()
    {
        int randomInt = Random.Range(1, spawnPoints.Length);
        Debug.Log(randomInt);
        Transform randomSpawner = spawnPoints[randomInt];
        Instantiate(zombie, randomSpawner.position, randomSpawner.rotation);
    }
}
