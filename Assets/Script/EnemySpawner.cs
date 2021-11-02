using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Text waveText;

    [SerializeField]
    private Text chrono;

    private int type1;

    private int type2;

    private int type3;

    public static int wave = 1;

    private float time;

    private void Start()
    {
        wave = 1;
        Converter();
        columns = GameObject.FindGameObjectsWithTag("Column");
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    private void Converter()
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
                columns[Random.Range(0, 5)].transform.position,
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
        StartCoroutine(WaveTransition());
    }

    private IEnumerator WaveTransition()
    {
        GameObject
            .Find("money")
            .GetComponent<MoneyBehavior>()
            .AddMoney(wave * 10);
        StartCoroutine(Chrono());
        yield return new WaitForSeconds(wave * 2);
        incrementWaveStrength *= 2;
        wave++;
        waveText.text = "Vague " + (wave);
        Converter();
        StartCoroutine(SpawnEnemy());
        foreach (GameObject item in type1Enemies)
        {
            item.GetComponent<EnemyBehavior>().multiplyHealth(1.2f);
        }
        foreach (GameObject item in type2Enemies)
        {
            item.GetComponent<EnemyBehavior>().multiplyHealth(1.2f);
        }
        foreach (GameObject item in type3Enemies)
        {
            item.GetComponent<EnemyBehavior>().multiplyHealth(1.2f);
        }
    }

    private IEnumerator Chrono()
    {
        spawnTime = spawnTime * 1.1f;
        float minusTime = 10 * wave / 10;
        float deltaTime = time;
        while (time < deltaTime + minusTime)
        {
            chrono.text = Mathf.Round(minusTime - (time - deltaTime)) + "s";
            yield return new WaitForSeconds(1);
        }
        chrono.text = "0s";
    }
}
