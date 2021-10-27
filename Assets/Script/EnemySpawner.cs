using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float spawnTime;

    [SerializeField]
    private int maxEnemies;

    private GameObject[] columns;

    // Start is called before the first frame update
    void Start()
    {
        columns = GameObject.FindGameObjectsWithTag("Column");
        StartCoroutine(SpawnEnemy());
        Debug.Log(columns.Length);
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            Instantiate(enemy,
            columns[Random.Range(0, 4)].transform.position,
            Quaternion.identity);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
