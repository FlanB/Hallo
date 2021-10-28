using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnTime;

    private GameObject[] columns;

    [SerializeField]
    private GameObject[] type1Enemies;

    [SerializeField]
    private GameObject[] type2Enemies;

    [SerializeField]
    private GameObject[] type3Enemies;

    [SerializeField]
    private int incrementWaveStrength;

    private int type1;

    private int type2;

    private int type3;

    void Start()
    {
        type1 = incrementWaveStrength;
        while (type1 >= 3 || type2 >= 2)
        {
            if (type1 >= 3)
            {
                type2++;
                type1 -= 3;
            }
            else if (type2 >= 2)
            {
                type3++;
                type2 -= 2;
            }
        }
        columns = GameObject.FindGameObjectsWithTag("Column");
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    if (type1 > 0)
                    {
                        type1--;
                        Instantiate(type1Enemies[Random
                            .Range(0, type1Enemies.Length)],
                        columns[Random.Range(0, 4)].transform.position,
                        Quaternion.identity);
                    }
                    else
                    {
                        Loop;
                    }
                    break;
                case 1:
                    if (type2 > 0)
                    {
                        type2--;
                        Instantiate(type2Enemies[Random
                            .Range(0, type2Enemies.Length)],
                        columns[Random.Range(0, 4)].transform.position,
                        Quaternion.identity);
                    }
                    else
                    {
                        Loop;
                    }
                    break;
                case 2:
                    if (type3 > 0)
                    {
                        type3--;
                        Instantiate(type3Enemies[Random
                            .Range(0, type3Enemies.Length)],
                        columns[Random.Range(0, 4)].transform.position,
                        Quaternion.identity);
                    }
                    else
                    {
                        Loop;
                    }
                    break;
            }
        }
        yield return new WaitForSeconds(spawnTime);
    }
}
