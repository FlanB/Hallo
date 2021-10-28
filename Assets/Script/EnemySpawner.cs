using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnTime;

    [SerializeField]
    private int incrementWaveStrength;

    [SerializeField]
    private int type1ToType2;

    [SerializeField]
    private int type2ToType3;

    private GameObject[] columns;

    [SerializeField]
    private GameObject[] type1Enemies;

    [SerializeField]
    private GameObject[] type2Enemies;

    [SerializeField]
    private GameObject[] type3Enemies;

    private int type1;

    private int type2;

    private int type3;

    void Start()
    {
        type1 = incrementWaveStrength;
        while (type1 >= type1ToType2 || type2 >= type2ToType3)
        {
            if (type1 >= type1ToType2)
            {
                type2++;
                type1 -= type1ToType2;
            }
            else if (type2 >= type2ToType3)
            {
                type3++;
                type2 -= type2ToType3;
            }
        }
        columns = GameObject.FindGameObjectsWithTag("Column");
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        int random = Random.Range(0, 2);

        for (int i = 0; i < type1 + type2 + type3; i++)
        {
            while (type1 > 0)
            {
                type1--;
                Instantiate(type1Enemies[Random.Range(0, type1Enemies.Length)],
                columns[Random.Range(0, 4)].transform.position,
                Quaternion.identity);
                yield return new WaitForSeconds(spawnTime);
            }
            while (type2 > 0)
            {
                type2--;
                Instantiate(type2Enemies[Random.Range(0, type2Enemies.Length)],
                columns[Random.Range(0, 4)].transform.position,
                Quaternion.identity);
                yield return new WaitForSeconds(spawnTime);
            }
            while (type3 > 0)
            {
                type3--;
                Instantiate(type3Enemies[Random.Range(0, type3Enemies.Length)],
                columns[Random.Range(0, 4)].transform.position,
                Quaternion.identity);
                yield return new WaitForSeconds(spawnTime);
            }
        }
    }
}
