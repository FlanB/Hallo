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

    private int spawnRow = 6;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            // spawn enemy in 5 columns
            switch (Random.Range(0, 4))
            {
                case 0:
                    Instantiate(enemy,
                    new Vector2(-2.25f, spawnRow),
                    Quaternion.identity);
                    break;
                case 1:
                    Instantiate(enemy,
                    new Vector2(-1.15f, spawnRow),
                    Quaternion.identity);
                    break;
                case 2:
                    Instantiate(enemy,
                    new Vector2(0, spawnRow),
                    Quaternion.identity);
                    break;
                case 3:
                    Instantiate(enemy,
                    new Vector2(1.15f, spawnRow),
                    Quaternion.identity);
                    break;
                case 4:
                    Instantiate(enemy,
                    new Vector2(2.25f, spawnRow),
                    Quaternion.identity);
                    break;
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
