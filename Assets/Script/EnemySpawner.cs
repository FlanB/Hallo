using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnTime;

    [SerializeField]
    private int maxEnemies;

    private GameObject[] columns;

    [SerializeField]
    private GameObject[] enemies;

    void Start()
    {
        columns = GameObject.FindGameObjectsWithTag("Column");
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)],
            columns[Random.Range(0, 4)].transform.position,
            Quaternion.identity);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
